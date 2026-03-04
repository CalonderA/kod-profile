using Telegram.Bot;
using Telegram.Bot.Types;

namespace ConsoleApp1;

public class WeekCommand : ICommand
{
    protected  readonly IScheduleRepository _scheduleRepository;

    public WeekCommand(IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }


    public async Task ExecuteAsync(Update update, ITelegramBotClient botClient, CancellationToken ct)
    {
        var chatId = update.Message!.Chat.Id;
        var text  = update.Message!.Text ?? string.Empty;
        
        // ожидаем формат: /week 9A
        if (string.IsNullOrWhiteSpace(text))
        {
            await botClient.SendTextMessageAsync(
                chatId,
                "Ожидаю команду вида: /week 9А",
                cancellationToken: ct);
            return;
        }
        
        var parts = text.Split(' ', 2,StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 2)
        {
            await botClient.SendTextMessageAsync(
                chatId,
                "Использование: /week [группа]\nНапример: /week 9A",
                cancellationToken: ct);
            return;
        }
        var groupName = parts[1].Trim();
        var shedule = _scheduleRepository.Load();
        var group = shedule.Groups
            .FirstOrDefault(g => string.Equals(g.Group, groupName, StringComparison.InvariantCultureIgnoreCase));
        

        if (group == null)
        {
            await botClient.SendTextMessageAsync(
                chatId, 
                $"Расписание для группы {groupName} не найдено.",
                cancellationToken: ct);
            return;
        }
        if (group == null)
        {
            await botClient.SendTextMessageAsync(
                chatId,$"Для группы {groupName} нет расписания.",
                cancellationToken: ct);
            return;
                
        }
        
        var lines = new List<string>{ $"Полное расписание для {groupName}:" };
        foreach (var day in group.Days)
        {
            lines.Add($"\n{day.Day}:");
            if (day.Lessons == null || day.Lessons.Count == 0)
            {
                lines.Add("  нет уроков");
            }
            else
            {
                lines.AddRange(
                    day.Lessons.Select(
                        (l, i) => $"  {i + 1}. {l.Time} -- {l.Subject} {(string.IsNullOrEmpty(l.Teacher) ? "" : "(" + l.Teacher + ")")}"
                    )
                );
            }
        }
      
        await botClient.SendTextMessageAsync(chatId, string.Join('\n', lines), cancellationToken: ct);
    }
}
