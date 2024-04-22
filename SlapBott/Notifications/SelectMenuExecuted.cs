
using Discord.WebSocket;
using MediatR;

namespace SlapBott.Notifications
{
    internal class SelectMenuExecuted(SocketMessageComponent component) : INotification
    {
        public readonly SocketMessageComponent Component = component;


    }
}
