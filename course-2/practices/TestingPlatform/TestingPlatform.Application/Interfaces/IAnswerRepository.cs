using TestingPlatform.Application.Dtos;

namespace TestingPlatform.Application.Interfaces;

public interface IAnswerRepository
{
    /// <summary>
    /// Получить все ответы.
    /// </summary>
    Task<IEnumerable<AnswerDto>> GetAllAsync();

    /// <summary>
    /// Получить ответ по идентификатору.
    /// </summary>
    Task<AnswerDto> GetByIdAsync(int id);

    /// <summary>
    /// Создать новый ответ.
    /// </summary>
    /// <returns>Идентификатор нового ответа.</returns>
    Task<int> CreateAsync(AnswerDto answerDto);

    /// <summary>
    /// Обновить ответ.
    /// </summary>
    Task UpdateAsync(AnswerDto answerDto);

    /// <summary>
    /// Удалить ответ.
    /// </summary>
    Task DeleteAsync(int id);
}
