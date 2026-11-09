namespace TestingPlatform.Requests.Group;

/// <summary>
/// Модель обновления группы
/// </summary>
public class UpdateGroupRequest
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название группы
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Идентификатор направления
    /// </summary>
    public int DirectionId { get; set; }

    /// <summary>
    /// Идентификатор курса
    /// </summary>
    public int CourseId { get; set; }

    /// <summary>
    /// Идентификатор проекта
    /// </summary>
    public int ProjectId { get; set; }
}
