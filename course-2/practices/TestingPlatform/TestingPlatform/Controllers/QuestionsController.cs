using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Requests.Question;
using TestingPlatform.Responses.Question;

namespace TestingPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionsController(IQuestionRepository questionRepository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получить список вопросов
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllQuestions()
    {
        var questions = await questionRepository.GetAllAsync();

        return Ok(mapper.Map<IEnumerable<QuestionResponse>>(questions));
    }

    /// <summary>
    /// Получить вопрос по идентификатору
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetQuestionById(int id)
    {
        var question = await questionRepository.GetByIdAsync(id);

        return Ok(mapper.Map<QuestionResponse>(question));
    }

    /// <summary>
    /// Создать вопрос
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionRequest question)
    {
        var id = await questionRepository.CreateAsync(mapper.Map<QuestionDto>(question));

        return StatusCode(StatusCodes.Status201Created, new { Id = id });
    }

    /// <summary>
    /// Обновить вопрос
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> UpdateQuestion([FromBody] UpdateQuestionRequest question)
    {
        await questionRepository.UpdateAsync(mapper.Map<QuestionDto>(question));

        return NoContent();
    }

    /// <summary>
    /// Удалить вопрос
    /// </summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteQuestion(int id)
    {
        await questionRepository.DeleteAsync(id);

        return NoContent();
    }
}
