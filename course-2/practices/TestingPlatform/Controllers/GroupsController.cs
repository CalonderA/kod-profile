using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestingPlatform.Data;
using TestingPlatform.Models;

namespace TestingPlatform.Controllers;

[ApiController]
[Route("api/[controller]")] // базовый маршрут: /api/groups
public class GroupsController : ControllerBase
{
    private readonly AppDbContext _db;

    public GroupsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult GetAllGroups()
    {
        var groups = _db.Groups.ToList();
        return Ok(groups); // 200
    }

    [HttpGet("{id:int}")]
    public IActionResult GetGroupById(int id)
    {
        if (id <= 0)
            return BadRequest("Некорректный id"); // 400

        var group = _db.Groups.FirstOrDefault(g => g.Id == id);
        if (group is null)
            return NotFound(); // 404

        return Ok(group); // 200
    }

    [HttpPost]
    public IActionResult CreateGroup([FromBody] Group group)
    {
        var nameExists = _db.Groups.Any(g => g.Name == group.Name);
        if (nameExists)
            return Conflict("Группа с таким названием уже существует"); // 409

        // проверяем, что связанные проект, направление и курс существуют
        var directionExists = _db.Directions.Any(d => d.Id == group.DirectionId);
        var courseExists = _db.Courses.Any(c => c.Id == group.CourseId);
        var projectExists = _db.Projects.Any(p => p.Id == group.ProjectId);
        if (!directionExists || !courseExists || !projectExists)
            return BadRequest("Направление, курс или проект с таким id не найдены"); // 400

        _db.Groups.Add(group);
        _db.SaveChanges();

        return Created($"/api/groups/{group.Id}", group); // 201 + Location
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateGroup([FromBody] Group group)
    {
        // Any не отслеживает сущность: иначе Entry(group) конфликтовал бы
        // с уже отслеживаемым экземпляром той же группы (ошибка 500)
        var exists = _db.Groups.Any(g => g.Id == group.Id);
        if (!exists)
            return NotFound();

        var nameInUse = _db.Groups.Any(g => g.Name == group.Name && g.Id != group.Id);
        if (nameInUse)
            return Conflict("Группа с таким названием уже существует"); // 409

        _db.Entry(group).State = EntityState.Modified;
        _db.SaveChanges();

        return NoContent(); // 204
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteGroup(int id)
    {
        var group = _db.Groups.Find(id);
        if (group is null)
            return NotFound();

        _db.Groups.Remove(group);
        _db.SaveChanges();

        return NoContent(); // 204
    }
}
