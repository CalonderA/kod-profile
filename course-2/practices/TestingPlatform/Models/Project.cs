namespace TestingPlatform.Models;

/// <summary>
/// Проект (например, КОД или ПАЗЛ)
/// </summary>
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
}
