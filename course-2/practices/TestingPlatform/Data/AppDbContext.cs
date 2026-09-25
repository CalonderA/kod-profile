using Microsoft.EntityFrameworkCore;
using TestingPlatform.Models;

namespace TestingPlatform.Data;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students => Set<Student>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // (необязательно) первичные данные, появятся после миграции
        // CreatedAt задан константой: динамические значения (DateTimeOffset.Now) в HasData
        // запрещены в EF Core 9+ — модель менялась бы при каждой сборке
        var createdAt = new DateTimeOffset(2026, 9, 1, 0, 0, 0, TimeSpan.Zero);
        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, Login = "vanya123", Email = "vanya123@mail.com", FirstName = "Иван", MiddleName = "Иванович", LastName = "Иванов", Phone = "+71234567890", VkProfileLink = "http://vk.com/vanya123", CreatedAt = createdAt },
            new Student { Id = 2, Login = "maria", Email = "maria@mail.com", FirstName = "Мария", MiddleName = "Ивановна", LastName = "Иванова", Phone = "+71234567899", VkProfileLink = "http://vk.com/vanya123", CreatedAt = createdAt }
        );
    }
}
