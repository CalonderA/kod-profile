using TestingPlatform.Domain.Enums;

namespace TestingPlatform.Domain.Models;


public class Question
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Текст вопроса
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Номер вопроса внутри теста (уникален в паре с TestId)
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Пояснение к вопросу (опционально, до 2000 символов)
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Тип вопроса (в БД хранится строкой)
    /// </summary>
    public AnswerType AnswerType { get; set; }

    /// <summary>
    /// Учитывается ли в баллах (по умолчанию true — задаёт БД)
    /// </summary>
    public bool IsScoring { get; set; }

    /// <summary>
    /// Максимальный балл за вопрос (опционально)
    /// </summary>
    public int? MaxScore { get; set; }

    /// <summary>
    /// Внешний ключ на тест
    /// </summary>
    public int TestId { get; set; }
    public Test Test { get; set; } = null!;

    /// <summary>
    /// Варианты ответа (1:many, каскадное удаление вместе с вопросом)
    /// </summary>
    public List<Answer> Answers { get; set; } = [];

    /// <summary>
    /// Ответы пользователей на этот вопрос
    /// </summary>
    public List<UserAttemptAnswer> UserAttemptAnswers { get; set; } = [];
}
