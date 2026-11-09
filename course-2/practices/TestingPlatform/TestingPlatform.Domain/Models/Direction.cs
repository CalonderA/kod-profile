namespace TestingPlatform.Domain.Models;


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

    /// <summary>
    /// Тесты, назначенные направлению (many:many через test_directions)
    /// </summary>
    public List<Test> Tests { get; set; } = [];
}
