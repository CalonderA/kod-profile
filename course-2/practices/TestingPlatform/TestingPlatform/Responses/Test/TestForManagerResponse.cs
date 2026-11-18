using TestingPlatform.Domain.Enums;
using TestingPlatform.Responses.Course;
using TestingPlatform.Responses.Direction;
using TestingPlatform.Responses.Group;
using TestingPlatform.Responses.Project;
using TestingPlatform.Responses.Student;

namespace TestingPlatform.Responses.Test;

public class TestForManagerResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsRepeatable { get; set; }
    public TestType Type { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime PublishedAt { get; set; }
    public DateTime Deadline { get; set; }
    public int? DurationMinutes { get; set; }
    public bool IsPublic { get; set; }
    public int? PassingScore { get; set; }
    public int? MaxAttempts { get; set; }

    /// <summary>
    /// Список студентов, для которых доступен тест (напрямую)
    /// </summary>
    public List<StudentForTestResponse> Students { get; set; } = [];

    /// <summary>
    /// Список проектов, для которых доступен тест
    /// </summary>
    public List<ProjectResponse> Projects { get; set; } = [];

    /// <summary>
    /// Список курсов, для которых доступен тест
    /// </summary>
    public List<CourseResponse> Courses { get; set; } = [];

    /// <summary>
    /// Список групп, для которых доступен тест
    /// </summary>
    public List<ShortGroupResponse> Groups { get; set; } = [];

    /// <summary>
    /// Список направлений, для которых доступен тест
    /// </summary>
    public List<DirectionResponse> Directions { get; set; } = [];
}
