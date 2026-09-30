namespace TestingPlatform.Models;

/// <summary>
/// Направление (например, фронтенд, бэкенд, дизайн)
/// </summary>
public class Direction
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название направления
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Группы направления
    /// </summary>
    public List<Group> Groups { get; set; } = [];
}
