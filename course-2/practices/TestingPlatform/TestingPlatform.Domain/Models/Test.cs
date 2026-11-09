using TestingPlatform.Domain.Enums;

namespace TestingPlatform.Domain.Models;

/// <summary>
/// Тест
/// </summary>
public class Test
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название теста
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Описание теста
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Можно ли проходить повторно (по умолчанию false — задаёт БД)
    /// </summary>
    public bool IsRepeatable { get; set; }

    /// <summary>
    /// Тип теста (в БД хранится строкой)
    /// </summary>
    public TestType Type { get; set; }

    /// <summary>
    /// Дата создания (задаёт БД через CURRENT_TIMESTAMP)
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата публикации
    /// </summary>
    public DateTime PublishedAt { get; set; }

    /// <summary>
    /// Крайний срок прохождения
    /// </summary>
    public DateTime Deadline { get; set; }

    /// <summary>
    /// Продолжительность в минутах (опционально)
    /// </summary>
    public int? DurationMinutes { get; set; }

    /// <summary>
    /// Публичный ли тест (по умолчанию false — задаёт БД)
    /// </summary>
    public bool IsPublic { get; set; }

    /// <summary>
    /// Проходной балл (опционально)
    /// </summary>
    public int? PassingScore { get; set; }

    /// <summary>
    /// Максимальное количество попыток (опционально)
    /// </summary>
    public int? MaxAttempts { get; set; }

    /// <summary>
    /// Вопросы теста (1:many, каскадное удаление)
    /// </summary>
    public List<Question> Questions { get; set; } = [];

    // Адресные назначения many:many — через явные join-таблицы (настройка в AppDbContext)
    public List<Student> Students { get; set; } = [];       // test_students
    public List<Group> Groups { get; set; } = [];           // test_groups
    public List<Project> Projects { get; set; } = [];       // test_projects
    public List<Course> Courses { get; set; } = [];         // test_courses
    public List<Direction> Directions { get; set; } = [];   // test_directions
}
