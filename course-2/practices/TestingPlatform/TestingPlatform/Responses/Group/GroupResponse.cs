using TestingPlatform.Responses.Course;
using TestingPlatform.Responses.Direction;
using TestingPlatform.Responses.Project;

namespace TestingPlatform.Responses.Group;

public class GroupResponse : BaseResponse
{
    /// <summary>
    /// Модель направления
    /// </summary>
    public DirectionResponse Direction { get; set; } = null!;

    /// <summary>
    /// Модель курса
    /// </summary>
    public CourseResponse Course { get; set; } = null!;

    /// <summary>
    /// Модель проекта
    /// </summary>
    public ProjectResponse Project { get; set; } = null!;
}
