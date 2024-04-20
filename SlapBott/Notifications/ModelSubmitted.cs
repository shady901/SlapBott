
using Discord.WebSocket;
using MediatR;

namespace SlapBott.Notifications
{
    internal class ModelSubmitted(SocketModal modal) : INotification
    {
        public SocketModal Modal { get; } = modal;


    }
}
