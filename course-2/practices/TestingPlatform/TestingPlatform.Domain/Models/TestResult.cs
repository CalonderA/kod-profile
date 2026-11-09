namespace TestingPlatform.Domain.Models;

/// <summary>
/// Итоговый результат прохождения теста (лучшая попытка)
/// </summary>
public class TestResult
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Пройден ли тест
    /// </summary>
    public bool Passed { get; set; }

    /// <summary>
    /// Внешний ключ на тест
    /// </summary>
    public int TestId { get; set; }
    public Test Test { get; set; } = null!;

    /// <summary>
    /// Внешний ключ на лучшую попытку
    /// </summary>
    public int AttemptId { get; set; }
    public Attempt Attempt { get; set; } = null!;

    /// <summary>
    /// Внешний ключ на студента
    /// </summary>
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
}
