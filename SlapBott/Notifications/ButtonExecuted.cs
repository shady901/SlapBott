
using Discord.WebSocket;
using MediatR;
using System.Net.Sockets;

namespace SlapBott.Notifications
{
    public class ButtonExecuted(SocketMessageComponent button) : INotification
    {
        public SocketMessageComponent socketButtonComponent { get; } = button;


    }
}