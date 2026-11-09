namespace TestingPlatform.Domain.Models;


public class Answer
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Текст варианта ответа
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Правильный ли вариант
    /// </summary>
    public bool IsCorrect { get; set; }

    /// <summary>
    /// Внешний ключ на вопрос
    /// </summary>
    public int QuestionId { get; set; }
    public Question Question { get; set; } = null!;

    /// <summary>
    /// Выбор этого варианта пользователями
    /// </summary>
    public List<UserSelectedOption> UserSelectedOptions { get; set; } = [];
}
