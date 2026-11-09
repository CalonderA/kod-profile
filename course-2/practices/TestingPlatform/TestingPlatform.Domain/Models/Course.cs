namespace TestingPlatform.Domain.Models;


public class Course
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название курса
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Группы курса
    /// </summary>
    public List<Group> Groups { get; set; } = [];

    /// <summary>
    /// Тесты, назначенные курсу (many:many через test_courses)
    /// </summary>
    public List<Test> Tests { get; set; } = [];
}
