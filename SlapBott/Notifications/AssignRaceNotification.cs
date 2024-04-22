using Discord.WebSocket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Notifications
{
    internal class AssignRaceNotification(SelectMenuExecuted notification) : INotification
    {
      public SocketMessageComponent Component = notification.Component;

    }
}
