namespace TestingPlatform.Application.Dtos;

public class GroupDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DirectionDto? Direction { get; set; }
    public CourseDto? Course { get; set; }
    public ProjectDto? Project { get; set; }
}
