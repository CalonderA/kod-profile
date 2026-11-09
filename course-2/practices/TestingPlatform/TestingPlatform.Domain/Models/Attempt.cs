namespace TestingPlatform.Domain.Models;


public class Attempt
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Время начала попытки (задаёт БД через CURRENT_TIMESTAMP)
    /// </summary>
    public DateTime StartedAt { get; set; }

    /// <summary>
    /// Время отправки (пока попытка не завершена — null)
    /// </summary>
    public DateTime? SubmittedAt { get; set; }

    /// <summary>
    /// Набранный балл (опционально)
    /// </summary>
    public int? Score { get; set; }

    /// <summary>
    /// Внешний ключ на тест
    /// </summary>
    public int TestId { get; set; }
    public Test Test { get; set; } = null!;

    /// <summary>
    /// Внешний ключ на студента
    /// </summary>
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;

    /// <summary>
    /// Ответы в рамках попытки (1:many)
    /// </summary>
    public List<UserAttemptAnswer> UserAttemptAnswers { get; set; } = [];
}
