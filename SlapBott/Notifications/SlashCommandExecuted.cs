using Discord.WebSocket;
using MediatR;

namespace SlapBott.Notifications
{
    internal class SlashCommandExecuted(SocketSlashCommand command) : INotification
    {
        private readonly SocketSlashCommand command = command;
    }
}
