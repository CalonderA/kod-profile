using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Data;
using TestingPlatform.Models;

namespace TestingPlatform.Controllers;

[ApiController]
[Route("api/[controller]")] // базовый маршрут: /api/students
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _db;

    public StudentsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult GetAllStudents()
    {
        var students = _db.Students.ToList();
        return Ok(students); // 200
    }

    [HttpGet("{id:int}")]
    public IActionResult GetStudentById(int id)
    {
        if (id <= 0)
            return BadRequest("Некорректный id"); // 400

        var student = _db.Students.FirstOrDefault(s => s.Id == id);
        if (student is null)
            return NotFound(); // 404

        return Ok(student); // 200
    }

    [HttpPost]
    public IActionResult CreateStudent([FromBody] Student student)
    {
        var emailExists = _db.Students.Where(s => s.User.Email == student.User.Email).ToList();
        if (emailExists.Any())
            return Conflict("Такой email уже используется"); // 409

        _db.Students.Add(student);
        _db.SaveChanges();

        return Created($"/api/students/{student.Id}", student); // 201 + Location
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateStudent([FromBody] Student student)
    {
        // Any не отслеживает сущность: иначе Entry(student) конфликтовал бы
        // с уже отслеживаемым экземпляром того же студента (ошибка 500)
        var exists = _db.Students.Any(s => s.Id == student.Id);
        if (!exists)
            return NotFound();

        var emailInUse = _db.Students.Any(s => s.User.Email == student.User.Email && s.Id != student.Id);
        if (emailInUse)
            return Conflict("Такой email уже используется"); // 409

        _db.Entry(student).State = EntityState.Modified;
        _db.SaveChanges();

        return NoContent(); // 204
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteStudent(int id)
    {
        var student = _db.Students.Find(id);
        if (student is null)
            return NotFound();

        _db.Students.Remove(student);
        _db.SaveChanges();

        return NoContent(); // 204
    }
}
