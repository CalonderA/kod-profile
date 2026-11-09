using Microsoft.EntityFrameworkCore;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastructure;

/// <summary>
/// Контекст БД: таблицы (DbSet), связи, ограничения и поведение при удалении.
/// По этой конфигурации EF строит схему базы данных при создании миграций.
/// </summary>
public class AppDbContext : DbContext
{
    // Каждый DbSet — таблица в БД
    public DbSet<User>                Users              => Set<User>();
    public DbSet<Student>             Students           => Set<Student>();
    public DbSet<Project>             Projects           => Set<Project>();
    public DbSet<Group>               Groups             => Set<Group>();
    public DbSet<Direction>           Directions         => Set<Direction>();
    public DbSet<Course>              Courses            => Set<Course>();
    public DbSet<Test>                Tests              => Set<Test>();
    public DbSet<Question>            Questions          => Set<Question>();
    public DbSet<Answer>              Answers            => Set<Answer>();
    public DbSet<Attempt>             Attempts           => Set<Attempt>();
    public DbSet<UserAttemptAnswer>   UserAttemptAnswers => Set<UserAttemptAnswer>();
    public DbSet<UserSelectedOption>  UserSelectedOptions => Set<UserSelectedOption>();
    public DbSet<UserTextAnswer>      UserTextAnswers    => Set<UserTextAnswer>();
    public DbSet<TestResult>          TestResults        => Set<TestResult>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Первичные данные справочников (появятся после миграции)
        modelBuilder.Entity<Project>().HasData(
            new Project { Id = 1, Name = "КОД" },
            new Project { Id = 2, Name = "ПАЗЛ" });

        modelBuilder.Entity<Course>().HasData(
            new Course { Id = 1, Name = "1 курс" },
            new Course { Id = 2, Name = "2 курс" });

        modelBuilder.Entity<Direction>().HasData(
            new Direction { Id = 1, Name = "Фронтенд" },
            new Direction { Id = 2, Name = "Бэкенд" },
            new Direction { Id = 3, Name = "Дизайн" });

        // ===== USER =====
        modelBuilder.Entity<User>(e =>
        {
            e.HasKey(x => x.Id);

            // Уникальные индексы: двух одинаковых логинов/email в БД не будет
            e.HasIndex(x => x.Login).IsUnique();
            e.HasIndex(x => x.Email).IsUnique();

            // NOT NULL: обязательные поля
            e.Property(x => x.Login).IsRequired();
            e.Property(x => x.Email).IsRequired();
            e.Property(x => x.PasswordHash).IsRequired();

            // Enum хранится в БД строкой ("Manager"/"Student"), а не числом:
            // значения в таблице читаемы и не «поедут» при расширении enum
            e.Property(x => x.Role).HasConversion<string>();

            // Значение по умолчанию на уровне БД: если CreatedAt не передан,
            // база сама запишет время создания строки
            e.Property(x => x.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Связь 1:1 User <-> Student.
            // FK хранится на стороне Student (UserId), уникальный индекс на UserId
            // гарантирует максимум одну запись студента у пользователя.
            // Cascade: при удалении User его Student удаляется автоматически.
            e.HasOne(x => x.Student)
                .WithOne(s => s.User)
                .HasForeignKey<Student>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // ===== STUDENT =====
        modelBuilder.Entity<Student>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Phone).IsRequired().HasMaxLength(30);
            e.Property(x => x.VkProfileLink).IsRequired();
            // Student <-> Group — many:many (EF сам создаст join-таблицу GroupStudent)
        });

        // ===== СПРАВОЧНИКИ: Direction, Course, Project =====
        // Название обязательно и уникально
        modelBuilder.Entity<Direction>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired();
            e.HasIndex(x => x.Name).IsUnique();
        });

        modelBuilder.Entity<Course>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired();
            e.HasIndex(x => x.Name).IsUnique();
        });

        modelBuilder.Entity<Project>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired();
            e.HasIndex(x => x.Name).IsUnique();
        });

        // ===== GROUP =====
        // Restrict: нельзя удалить Direction/Course/Project, пока к ним привязаны группы
        modelBuilder.Entity<Group>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired();
            e.HasIndex(x => x.Name).IsUnique();

            // 1:many: один справочник -> много групп, FK на стороне "многих" (Groups)
            e.HasOne(x => x.Direction)
                .WithMany(d => d.Groups)
                .HasForeignKey(x => x.DirectionId)
                .OnDelete(DeleteBehavior.Restrict);

            e.HasOne(x => x.Course)
                .WithMany(c => c.Groups)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            e.HasOne(x => x.Project)
                .WithMany(p => p.Groups)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // ===== TEST =====
        modelBuilder.Entity<Test>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Title).IsRequired();
            e.Property(x => x.Description).IsRequired();

            // Дефолты false: если значение не передано, БД запишет false
            e.Property(x => x.IsRepeatable).HasDefaultValue(false);
            e.Property(x => x.IsPublic).HasDefaultValue(false);

            e.Property(x => x.Type).HasConversion<string>();
            e.Property(x => x.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            e.Property(x => x.PublishedAt).IsRequired();
            e.Property(x => x.Deadline).IsRequired();

            // 1:many Test -> Questions, Cascade: удалили тест — вопросы удаляются сами
            e.HasMany(x => x.Questions)
                .WithOne(q => q.Test)
                .HasForeignKey(q => q.TestId)
                .OnDelete(DeleteBehavior.Cascade);

            // Адресные назначения many:many — явные join-таблицы.
            // В каждой join-таблице лежат пары внешних ключей (TestId, ...Id):
            // один тест, назначенный трём студентам = 3 строки в test_students
            e.HasMany(x => x.Students)
                .WithMany(s => s.Tests)
                .UsingEntity(j => j.ToTable("test_students"));

            e.HasMany(x => x.Groups)
                .WithMany(g => g.Tests)
                .UsingEntity(j => j.ToTable("test_groups"));

            e.HasMany(x => x.Projects)
                .WithMany(p => p.Tests)
                .UsingEntity(j => j.ToTable("test_projects"));

            e.HasMany(x => x.Courses)
                .WithMany(c => c.Tests)
                .UsingEntity(j => j.ToTable("test_courses"));

            e.HasMany(x => x.Directions)
                .WithMany(d => d.Tests)
                .UsingEntity(j => j.ToTable("test_directions"));
        });

        // ===== QUESTION =====
        modelBuilder.Entity<Question>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Text).IsRequired();
            e.Property(x => x.Description).HasMaxLength(2000);
            e.Property(x => x.AnswerType).HasConversion<string>();

            // Дефолт true: если значение не передано, БД запишет true
            e.Property(x => x.IsScoring).HasDefaultValue(true);

            // Составной уникальный индекс: номер вопроса уникален ВНУТРИ одного теста.
            // Нельзя уникализировать только Number — иначе номер 1 существовал бы
            // лишь в одном тесте во всей системе
            e.HasIndex(x => new { x.TestId, x.Number }).IsUnique();
        });

        // ===== ANSWER =====
        modelBuilder.Entity<Answer>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Text).IsRequired();

            // Cascade: удалили вопрос — его варианты ответа удаляются
            e.HasOne(x => x.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // ===== ATTEMPT =====
        modelBuilder.Entity<Attempt>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.StartedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Restrict: нельзя удалить тест, по которому есть попытки —
            // иначе потеряется история прохождений
            e.HasOne(x => x.Test)
                .WithMany()
                .HasForeignKey(x => x.TestId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cascade: удалили студента — его попытки удаляются
            e.HasOne(x => x.Student)
                .WithMany(s => s.Attempts)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // ===== USER ATTEMPT ANSWER =====
        modelBuilder.Entity<UserAttemptAnswer>(e =>
        {
            e.HasKey(x => x.Id);

            // Cascade: удалили попытку — все её ответы удаляются
            e.HasOne(x => x.Attempt)
                .WithMany(a => a.UserAttemptAnswers)
                .HasForeignKey(x => x.AttemptId)
                .OnDelete(DeleteBehavior.Cascade);

            // Restrict: нельзя удалить вопрос, на который уже отвечали в попытках —
            // это история прохождений
            e.HasOne(x => x.Question)
                .WithMany(q => q.UserAttemptAnswers)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Составной уникальный индекс: один ответ на вопрос в рамках одной попытки
            e.HasIndex(x => new { x.AttemptId, x.QuestionId }).IsUnique();

            // 1:1 UserAttemptAnswer <-> UserTextAnswer (для Text-вопросов).
            // FK на стороне UserTextAnswer, Cascade: удалили ответ — удалился и текст
            e.HasOne(x => x.UserTextAnswer)
                .WithOne(t => t.UserAttemptAnswer)
                .HasForeignKey<UserTextAnswer>(t => t.UserAttemptAnswerId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // ===== USER SELECTED OPTION =====
        modelBuilder.Entity<UserSelectedOption>(e =>
        {
            e.HasKey(x => x.Id);

            // Cascade: удалили ответ пользователя — его выбор удаляется
            e.HasOne(x => x.UserAttemptAnswer)
                .WithMany(a => a.UserSelectedOptions)
                .HasForeignKey(x => x.UserAttemptAnswerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Restrict: нельзя удалить вариант ответа, который кто-то уже выбирал
            e.HasOne(x => x.Answer)
                .WithMany(a => a.UserSelectedOptions)
                .HasForeignKey(x => x.AnswerId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // ===== USER TEXT ANSWER =====
        modelBuilder.Entity<UserTextAnswer>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.TextAnswer).IsRequired();
        });

        // ===== TEST RESULT =====
        modelBuilder.Entity<TestResult>(e =>
        {
            e.HasKey(x => x.Id);

            // Restrict: нельзя удалить тест с сохранёнными результатами
            e.HasOne(x => x.Test)
                .WithMany()
                .HasForeignKey(x => x.TestId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cascade: удалили попытку/студента — результат удаляется
            e.HasOne(x => x.Attempt)
                .WithMany()
                .HasForeignKey(x => x.AttemptId)
                .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(x => x.Student)
                .WithMany(s => s.TestResults)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Составной уникальный индекс: один результат на пару (тест, студент, попытка)
            e.HasIndex(x => new { x.TestId, x.StudentId, x.AttemptId }).IsUnique();
        });
    }
}
