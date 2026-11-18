namespace TestingPlatform.Infrastructure.Exceptions;

/// <summary>
/// Сущность не найдена.
/// </summary>
public class EntityNotFoundException(string message) : Exception(message) { }
