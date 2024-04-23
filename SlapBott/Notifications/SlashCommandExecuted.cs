using Discord.WebSocket;
using MediatR;

namespace SlapBott.Notifications
{
    public class SlashCommandExecuted(SocketSlashCommand command) : INotification
    {
        private readonly SocketSlashCommand command = command;
    }
}
