using Microsoft.AspNetCore.Mvc;

namespace TestingPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]        // базовый маршрут: /api/students
public class StudentsController : ControllerBase
{
    // Шаг 3. Получение списка студентов
    [HttpGet]
    public IActionResult GetAllStudents() => Ok("Список студентов"); // 200

    // Шаг 4. Получение студента по id
    [HttpGet("{id:int}")]
    public IActionResult GetStudentById(int id)
    {
        if (id <= 0)
            return BadRequest("Некорректный id"); // 400
        if (id == 1)
            return Ok("Студент 1"); // 200 (заглушка)
        return NotFound(); // 404
    }

    // Шаг 5. Создание студента
    [HttpPost]
    public IActionResult CreateStudent()
    {
        // Имитация: создали студента с id=1
        return Created("/api/students/1", "Создан студент с id=1"); // 201 + Location
    }

    // Шаг 6. Обновление данных о студенте
    [HttpPut("{id:int}")]
    public IActionResult UpdateStudent(int id)
    {
        if (id <= 0)
            return BadRequest("Некорректный id"); // 400
        // Имитация: если не существует
        if (id != 1)
            return NotFound(); // 404
        // Имитация: обновили
        return NoContent(); // 204
    }

    // Шаг 7. Удаление студента
    [HttpDelete("{id:int}")]
    public IActionResult DeleteStudent(int id)
    {
        if (id <= 0)
            return BadRequest("Некорректный id"); // 400
        if (id != 1)
            return NotFound(); // 404
        return NoContent(); // 204
    }
}
