using Telegram.Bot;
using Telegram.Bot.Types;

namespace ConsoleApp1;

public class TodayCommand : ICommand
{
    
    protected readonly IScheduleRepository _scheduleRepository;

    public TodayCommand(IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }
    
    
    public async Task ExecuteAsync(Update update, ITelegramBotClient botClient, CancellationToken ct)
    {
       var chatId = update.Message!.Chat.Id;
       var text = update.Message!.Text ?? string.Empty;

       var parts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
       string groupName;

       if (parts.Length >= 2)
       {
           groupName = parts[1].Trim(); 
       }
       else
       {
           await botClient.SendTextMessageAsync(chatId,
               "Использование: /today [группа]\nНапример: /today 9A",
               cancellationToken: ct);
           return;
       }

       var schedule = _scheduleRepository.Load();
       var group = schedule.Groups 
           .FirstOrDefault(g => string.Equals(g.Group, groupName, StringComparison.CurrentCultureIgnoreCase));
       
       if (group == null)
       {
           await botClient.SendTextMessageAsync(
               chatId,
               $"Для группы {groupName} нет расписания.",
               cancellationToken: ct);
           return;
       }
       
       var todayEnglish = DateTime.Today.DayOfWeek.ToString(); 

       var todaySchedule = group.Days
           .FirstOrDefault(d => string.Equals(d.Day, todayEnglish, StringComparison.OrdinalIgnoreCase));

       var lines = new List<string> { $"Расписание для {groupName} на сегодня ({todayEnglish}):" };

       if (todaySchedule == null || todaySchedule.Lessons == null || todaySchedule.Lessons.Count == 0)
       {
           lines.Add("Сегодня уроков нет 🎉");
       }
       else
       {
           var validLessons = todaySchedule.Lessons
               .Where(l => !string.IsNullOrWhiteSpace(l.Time) && !string.IsNullOrWhiteSpace(l.Subject))
               .ToList();

           if (validLessons.Count == 0)
           {
               lines.Add("Сегодня уроков нет ");
           }
           else
           {
               lines.AddRange(
                   validLessons.Select((l, i) =>
                       $"  {i + 1}. {l.Time} — {l.Subject}" +
                       (string.IsNullOrEmpty(l.Teacher) ? "" : $" ({l.Teacher})") +
                       (string.IsNullOrEmpty(l.Classroom) ? "" : $" каб. {l.Classroom}") +
                       (l.IsRed ? " ⚠️" : "")
                   )
               );
           }
       }

       await botClient.SendTextMessageAsync(
           chatId,
           string.Join("\n", lines),
           cancellationToken: ct);
    }
}