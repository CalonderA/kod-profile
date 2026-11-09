using System;
using System.Text.Json.Serialization;
using TestingPlatform.Domain.Enums;

namespace TestingPlatform.Domain.Models;

/// <summary>
/// Пользователь
/// </summary>
public class User
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Логин
    /// </summary>
    public string Login { get; set; } = string.Empty;

    /// <summary>
    /// Хеш пароля (в БД хранится только хеш, не сам пароль)
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;

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
    /// Роль (менеджер или студент)
    /// </summary>
    public UserRole Role { get; set; }

    /// <summary>
    /// Время создания (заполняется БД автоматически через CURRENT_TIMESTAMP)
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Если роль студент - должна быть запись в таблице Student
    /// </summary>
    [JsonIgnore]
    public Student? Student { get; set; }
}
