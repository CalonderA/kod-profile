using Telegram.Bot;
using Telegram.Bot.Types;

namespace ConsoleApp1;

public interface ICommand
{
    Task ExecuteAsync(Update update, ITelegramBotClient botClient, CancellationToken ct);

}