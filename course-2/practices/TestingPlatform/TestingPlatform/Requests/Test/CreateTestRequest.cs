using System.ComponentModel.DataAnnotations;
using TestingPlatform.Domain.Enums;

namespace TestingPlatform.Requests.Test;

/// <summary>
/// Модель создания теста
/// </summary>
public class CreateTestRequest
{
    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    public bool IsRepeatable { get; set; }
    public TestType Type { get; set; }
    public DateTime PublishedAt { get; set; }
    public DateTime Deadline { get; set; }
    public int? DurationMinutes { get; set; }
    public int? PassingScore { get; set; }
    public int? MaxAttempts { get; set; }

    public List<int> Students { get; set; } = [];
    public List<int> Projects { get; set; } = [];
    public List<int> Courses { get; set; } = [];
    public List<int> Groups { get; set; } = [];
    public List<int> Directions { get; set; } = [];
}
