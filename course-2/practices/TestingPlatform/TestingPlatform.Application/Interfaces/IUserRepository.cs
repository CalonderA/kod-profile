using TestingPlatform.Application.Dtos;

namespace TestingPlatform.Application.Interfaces;

public interface IUserRepository
{
    /// <summary>
    /// Получить всех пользователей.
    /// </summary>
    Task<IEnumerable<UserDto>> GetAllAsync();

    /// <summary>
    /// Получить пользователя по идентификатору.
    /// </summary>
    Task<UserDto> GetByIdAsync(int id);

    /// <summary>
    /// Регистрация нового пользователя.
    /// </summary>
    /// <returns>Идентификатор нового пользователя.</returns>
    Task<int> CreateAsync(UserDto userDto);

    /// <summary>
    /// Обновить информацию о пользователе.
    /// </summary>
    Task UpdateAsync(UserDto userDto);

    /// <summary>
    /// Удалить пользователя.
    /// </summary>
    Task DeleteAsync(int id);
}
