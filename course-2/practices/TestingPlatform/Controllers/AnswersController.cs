using Microsoft.AspNetCore.Mvc;

namespace TestingPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnswersController : ControllerBase
{
    // Получение всех ответов
    [HttpGet]
    public IActionResult GetAllAnswers() => Ok("Список всех ответов");

    // Получение ответа по id
    [HttpGet("{id:int}")]
    public IActionResult GetAnswerById(int id)
    {
        if (id <= 0)
            return BadRequest("Некорректный id"); 
        if (id == 1)
            return Ok("Ответ 1"); 
        return NotFound(); 
    }

    // Ответы на конкретный вопрос
    [HttpGet("by-question/{questionId:int}")]
    public IActionResult GetAnswersByQuestionId(int questionId) => Ok($"Ответы на вопрос {questionId}");

    // Ответы студента на конкретный тест
    [HttpGet("by-student/{studentId:int}/by-test/{testId:int}")]
    public IActionResult GetAnswersByStudentAndTest(int studentId, int testId)
        => Ok($"Ответы студента {studentId} на тест {testId}");

    // Добавление ответа
    [HttpPost]
    public IActionResult CreateAnswer()
    {
        // Имитация: создали ответ с id=1
        return Created("/api/answers/1", "Ответ создан"); 
    }

    // Изменение ответа
    [HttpPut("{id:int}")]
    public IActionResult UpdateAnswer(int id)
    {
        if (id <= 0)
            return BadRequest("Некорректный id"); 
        if (id != 1)
            return NotFound(); 
        return NoContent(); 
    }

    // Удаление ответа
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnswer(int id)
    {
        if (id <= 0)
            return BadRequest("Некорректный id"); 
        if (id != 1)
            return NotFound();
        return NoContent(); 
    }
}
