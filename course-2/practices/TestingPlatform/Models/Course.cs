namespace TestingPlatform.Models;

/// <summary>
/// Курс (например, 1 курс, 2 курс)
/// </summary>
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
}
