namespace TestingPlatform.Domain.Models;


public class UserTextAnswer
{
    
    /// Идентификатор
   
    public int Id { get; set; }

   
    /// Текст ответа
    public string TextAnswer { get; set; } = string.Empty;
    
    /// Внешний ключ на ответ пользователя (уникальный — обеспечивает 1:1)
    public int UserAttemptAnswerId { get; set; }
    public UserAttemptAnswer UserAttemptAnswer { get; set; } = null!;
}
