using Microsoft.EntityFrameworkCore;
using TestingPlatform.Models;

namespace TestingPlatform.Data;

public class AppDbContext : DbContext
{
    public DbSet<User>       Users       => Set<User>();
    public DbSet<Student>    Students    => Set<Student>();
    public DbSet<Project>    Projects    => Set<Project>();
    public DbSet<Group>      Groups      => Set<Group>();
    public DbSet<Direction>  Directions  => Set<Direction>();
    public DbSet<Course>     Courses     => Set<Course>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Справочные данные: проекты, курсы, направления (появятся после миграции)
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
    }
}
