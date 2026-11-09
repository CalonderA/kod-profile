namespace TestingPlatform.Responses;

/// <summary>
/// Базовая модель ответа
/// </summary>
public class BaseResponse
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
