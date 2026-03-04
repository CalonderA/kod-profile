using Telegram.Bot;
using Telegram.Bot.Types;

namespace ConsoleApp1;

public class HelpCommand : ICommand
{
    public async Task ExecuteAsync(Update update, ITelegramBotClient botClient, CancellationToken ct)
    {
        var chatId = update.Message!.Chat.Id;
        string text = "Доступные команды:\n" +
                      "/start - приветствие\n" +
                      "/help - помощь\n" +
                      "/week [группа] — показать расписание на неделю для указанной группы\n" +
                      "/today — показывает расписание только на сегодня (для текущей группы)\n";
        await botClient.SendTextMessageAsync(chatId,text,cancellationToken: ct);
    }
}