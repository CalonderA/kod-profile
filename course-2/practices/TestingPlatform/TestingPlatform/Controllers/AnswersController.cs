using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Requests.Answer;
using TestingPlatform.Responses.Answer;

namespace TestingPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnswersController(IAnswerRepository answerRepository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получить список ответов
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllAnswers()
    {
        var answers = await answerRepository.GetAllAsync();

        return Ok(mapper.Map<IEnumerable<AnswerResponse>>(answers));
    }

    /// <summary>
    /// Получить ответ по идентификатору
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAnswerById(int id)
    {
        var answer = await answerRepository.GetByIdAsync(id);

        return Ok(mapper.Map<AnswerResponse>(answer));
    }

    /// <summary>
    /// Создать ответ
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateAnswer([FromBody] CreateAnswerRequest answer)
    {
        var id = await answerRepository.CreateAsync(mapper.Map<AnswerDto>(answer));

        return StatusCode(StatusCodes.Status201Created, new { Id = id });
    }

    /// <summary>
    /// Обновить ответ
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> UpdateAnswer([FromBody] UpdateAnswerRequest answer)
    {
        await answerRepository.UpdateAsync(mapper.Map<AnswerDto>(answer));

        return NoContent();
    }

    /// <summary>
    /// Удалить ответ
    /// </summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAnswer(int id)
    {
        await answerRepository.DeleteAsync(id);

        return NoContent();
    }
}
