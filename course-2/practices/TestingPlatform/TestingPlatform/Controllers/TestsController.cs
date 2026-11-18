using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Requests.Test;
using TestingPlatform.Responses.Test;

namespace TestingPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestsController(ITestRepository testRepository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получить список тестов с фильтрацией
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllTests(
        [FromQuery] bool? isPublic,
        [FromQuery] List<int>? groupIds,
        [FromQuery] List<int>? studentIds)
    {
        var tests = await testRepository.GetAllAsync(isPublic, groupIds ?? [], studentIds ?? []);

        return Ok(mapper.Map<IEnumerable<TestForManagerResponse>>(tests));
    }

    /// <summary>
    /// Получить список тестов для менеджера
    /// </summary>
    [HttpGet("manage")]
    public async Task<IActionResult> GetAllTestsForManager(
        [FromQuery] bool? isPublic,
        [FromQuery] List<int>? groupIds,
        [FromQuery] List<int>? studentIds)
    {
        var tests = await testRepository.GetAllAsync(isPublic, groupIds ?? [], studentIds ?? []);

        return Ok(mapper.Map<IEnumerable<TestForManagerResponse>>(tests));
    }

    /// <summary>
    /// Получить тест по идентификатору для менеджера
    /// </summary>
    [HttpGet("{id:int}/manage")]
    public async Task<IActionResult> GetTestByIdForManager(int id)
    {
        var test = await testRepository.GetByIdAsync(id);

        return Ok(mapper.Map<TestForManagerResponse>(test));
    }

    /// <summary>
    /// Получить тесты, доступные студенту
    /// </summary>
    [HttpGet("for-student/{studentId:int}")]
    public async Task<IActionResult> GetTestsForStudent(int studentId)
    {
        var tests = await testRepository.GetAllForStudent(studentId);

        return Ok(mapper.Map<IEnumerable<TestForStudentResponse>>(tests));
    }

    /// <summary>
    /// Получить последние опубликованные тесты
    /// </summary>
    [HttpGet("top-recent")]
    public async Task<IActionResult> GetTopRecentTests([FromQuery] int count = 5)
    {
        var tests = await testRepository.GetTopRecentAsync(count);

        return Ok(mapper.Map<IEnumerable<TestForStudentResponse>>(tests));
    }

    /// <summary>
    /// Статистика по тестам (LINQ-практика)
    /// </summary>
    [HttpGet("statistics")]
    public async Task<IActionResult> GetStatistics([FromQuery] int top = 10)
    {
        return Ok(new
        {
            ByType = await testRepository.GetTestCountByTypeAsync(),
            ByCourse = await testRepository.GetCourseStatsAsync(),
            ByDirection = await testRepository.GetDirectionAveragesAsync(),
            Timeline = await testRepository.GetTestTimelineByPublicAsync(),
            TopGroups = await testRepository.GetTopGroupsByTestCountAsync(top)
        });
    }

    /// <summary>
    /// Получить тест по идентификатору
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetTestById(int id)
    {
        var test = await testRepository.GetByIdAsync(id);

        return Ok(mapper.Map<TestForManagerResponse>(test));
    }

    /// <summary>
    /// Создать тест
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateTest([FromBody] CreateTestRequest test)
    {
        var id = await testRepository.CreateAsync(mapper.Map<TestDto>(test));

        return StatusCode(StatusCodes.Status201Created, new { Id = id });
    }

    /// <summary>
    /// Обновить тест
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> UpdateTest([FromBody] UpdateTestRequest test)
    {
        await testRepository.UpdateAsync(mapper.Map<TestDto>(test));

        return NoContent();
    }

    /// <summary>
    /// Удалить тест
    /// </summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTest(int id)
    {
        await testRepository.DeleteAsync(id);

        return NoContent();
    }
}
