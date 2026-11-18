using TestingPlatform.Application.Dtos;

namespace TestingPlatform.Application.Interfaces;

public interface IQuestionRepository
{
    /// <summary>
    /// Получить все вопросы.
    /// </summary>
    Task<IEnumerable<QuestionDto>> GetAllAsync();

    /// <summary>
    /// Получить вопрос по идентификатору.
    /// </summary>
    Task<QuestionDto> GetByIdAsync(int id);

    /// <summary>
    /// Создать новый вопрос.
    /// </summary>
    /// <returns>Идентификатор нового вопроса.</returns>
    Task<int> CreateAsync(QuestionDto questionDto);

    /// <summary>
    /// Обновить информацию о вопросе.
    /// </summary>
    Task UpdateAsync(QuestionDto questionDto);

    /// <summary>
    /// Удалить вопрос.
    /// </summary>
    Task DeleteAsync(int id);
}
