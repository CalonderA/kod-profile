namespace ConsoleApp1;

public class Lesson
{
    public string Time      { get; set; } = string.Empty;
    public string Subject   { get; set; } = string.Empty;
    public string Teacher   { get; set; } = string.Empty;
    public string Classroom { get; set; } = string.Empty;
    public string Note      { get; set; } = string.Empty;
    public bool   IsRed     { get; set; }

    // Добавляем конструктор
    public Lesson(string time, string subject, string teacher)
    {
        Time    = time    ?? string.Empty;
        Subject = subject ?? string.Empty;
        Teacher = teacher ?? string.Empty;
    }

    // Пустой конструктор — важен для десериализации JSON
    public Lesson() { }
}