namespace TestingPlatform.Models;

/// <summary>
/// Студент
/// </summary>
public class Student
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Логин
    /// </summary>
    public string Login { get; set; } = string.Empty;

    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Отчество
    /// </summary>
    public string? MiddleName { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Ссылка на профиль студента в ВК
    /// </summary>
    public string VkProfileLink { get; set; } = string.Empty;

    /// <summary>
    /// Дата создания пользователя
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }
}
