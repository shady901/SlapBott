
using Discord.WebSocket;
using MediatR;

namespace SlapBott.Notifications
{
    internal class SelectMenuExecuted(SocketMessageComponent component) : INotification
    {
        private readonly SocketMessageComponent _component = component;


    }
}
