
using Discord.WebSocket;
using MediatR;

namespace SlapBott.Notifications
{
    public class SelectMenuExecuted(SocketMessageComponent component) : INotification
    {
        public readonly SocketMessageComponent Component = component;


    }
}
