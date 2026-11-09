using TestingPlatform.Responses.Course;
using TestingPlatform.Responses.Direction;
using TestingPlatform.Responses.Group;
using TestingPlatform.Responses.Project;
using TestingPlatform.Responses.Student;
using TestingPlatform.Domain.Enums;

namespace TestingPlatform.Responses.Test;

public class TestResponse
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

    public List<StudentResponse> Students { get; set; } = [];
    public List<ProjectResponse> Projects { get; set; } = [];
    public List<CourseResponse> Courses { get; set; } = [];
    public List<GroupResponse> Groups { get; set; } = [];
    public List<DirectionResponse> Directions { get; set; } = [];
}
