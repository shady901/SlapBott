using Discord.WebSocket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Notifications
{
    public class SelectMenuUsedSkillNotification(SocketMessageComponent socketMessageComponent):INotification
    {
        public SocketMessageComponent messageComponent = socketMessageComponent;
    }
}
