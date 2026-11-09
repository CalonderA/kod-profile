using TestingPlatform.Application.Dtos;

namespace TestingPlatform.Application.Interfaces;

public interface IStudentRepository
{
    /// <summary>
    /// Получить список студентов.
    /// </summary>
    Task<IEnumerable<StudentDto>> GetAllAsync();

    /// <summary>
    /// Получить студента по идентификатору.
    /// </summary>
    Task<StudentDto> GetByIdAsync(int id);

    /// <summary>
    /// Добавить нового студента.
    /// </summary>
    /// <returns>Идентификатор нового студента.</returns>
    Task<int> CreateAsync(StudentDto studentDto);

    /// <summary>
    /// Обновить информацию о студенте.
    /// </summary>
    Task UpdateAsync(StudentDto studentDto);

    /// <summary>
    /// Удалить студента.
    /// </summary>
    Task DeleteAsync(int id);
}
