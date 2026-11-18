using TestingPlatform.Application.Dtos;

namespace TestingPlatform.Application.Interfaces;

public interface ITestRepository
{
    /// <summary>
    /// Получить все тесты.
    /// </summary>
    /// <param name="isPublic">Опубликован ли тест</param>
    /// <param name="groupIds">Идентификаторы групп</param>
    /// <param name="studentIds">Идентификаторы студентов</param>
    Task<IEnumerable<TestDto>> GetAllAsync(bool? isPublic, List<int> groupIds, List<int> studentIds);

    /// <summary>
    /// Получить все тесты для студента.
    /// </summary>
    Task<IEnumerable<TestDto>> GetAllForStudent(int studentId);

    /// <summary>
    /// Получить тест по идентификатору.
    /// </summary>
    Task<TestDto> GetByIdAsync(int id);

    /// <summary>
    /// Получить последние N опубликованных тестов.
    /// </summary>
    Task<IEnumerable<TestDto>> GetTopRecentAsync(int count = 5);

    /// <summary>
    /// Создать новый тест.
    /// </summary>
    /// <returns>Идентификатор нового теста.</returns>
    Task<int> CreateAsync(TestDto testDto);

    /// <summary>
    /// Обновить информацию о тесте.
    /// </summary>
    Task UpdateAsync(TestDto testDto);

    /// <summary>
    /// Удалить тест.
    /// </summary>
    Task DeleteAsync(int id);

    /// <summary>
    /// Количество тестов по типам.
    /// </summary>
    Task<IEnumerable<object>> GetTestCountByTypeAsync();

    /// <summary>
    /// Средняя длительность и средний проходной балл по курсам.
    /// </summary>
    Task<IEnumerable<object>> GetCourseStatsAsync();

    /// <summary>
    /// Средние показатели тестов по направлениям.
    /// </summary>
    Task<IEnumerable<object>> GetDirectionAveragesAsync();

    /// <summary>
    /// Количество тестов по публичности и месяцу публикации.
    /// </summary>
    Task<IEnumerable<object>> GetTestTimelineByPublicAsync();

    /// <summary>
    /// Топ групп по количеству назначенных тестов.
    /// </summary>
    Task<IEnumerable<object>> GetTopGroupsByTestCountAsync(int top = 10);
}
