
namespace TestingPlatform.Domain.Models;


public class Student
{
   
    public int Id { get; set; }

   
    public string Phone { get; set; } = string.Empty;

  
    public string VkProfileLink { get; set; } = string.Empty;

    
    /// 1:1 к пользователю (обязателен для студента).
    /// Это внешний ключ: лежит на стороне Student.
    /// Уникальный индекс на UserId делает связь именно 1:1 —
    /// два студента не могут ссылаться на одного пользователя.
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    
    
    /// Группы студента 
    public List<Group> Groups { get; set; } = [];

   
    /// Тесты, адресно назначенные студенту (many:many через test_students)
    public List<Test> Tests { get; set; } = [];

   
    /// Попытки прохождения тестов (1:many)
    public List<Attempt> Attempts { get; set; } = [];
    
    /// Результаты тестов (1:many)
    public List<TestResult> TestResults { get; set; } = [];
}
