namespace TestingPlatform.Domain.Models;


public class UserAttemptAnswer
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Правильный ли ответ (null — ещё не проверен)
    /// </summary>
    public bool? IsCorrect { get; set; }

    /// <summary>
    /// Начисленный балл (0/1 или до MaxScore вопроса)
    /// </summary>
    public int? ScoreAwarded { get; set; }

    /// <summary>
    /// Внешний ключ на попытку
    /// </summary>
    public int AttemptId { get; set; }
    public Attempt Attempt { get; set; } = null!;

    /// <summary>
    /// Внешний ключ на вопрос
    /// </summary>
    public int QuestionId { get; set; }
    public Question Question { get; set; } = null!;

    /// <summary>
    /// Выбранные варианты (для Single/Multiple вопросов)
    /// </summary>
    public List<UserSelectedOption> UserSelectedOptions { get; set; } = [];

    /// <summary>
    /// Текстовый ответ (для Text-вопросов), 1:1
    /// </summary>
    public UserTextAnswer? UserTextAnswer { get; set; }
}
