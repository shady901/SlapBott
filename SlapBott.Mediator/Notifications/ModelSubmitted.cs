
using Discord.WebSocket;
using MediatR;

namespace SlapBott.Notifications
{
    public class ModelSubmitted(SocketModal modal) : INotification
    {
        public SocketModal Modal { get; } = modal;


    }
}
