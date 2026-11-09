namespace TestingPlatform.Domain.Models;


public class Project
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название проекта
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Группы проекта
    /// </summary>
    public List<Group> Groups { get; set; } = [];

    /// <summary>
    /// Тесты, назначенные проекту (many:many через test_projects)
    /// </summary>
    public List<Test> Tests { get; set; } = [];
}
