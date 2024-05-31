using MediatR;
using SlapBott.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Handlers
{


    //this occurs when player character dies, think we have it so that the players items get reduced such as materials ect idk how hardcore to go
    public class PlayerCharacterDiedHandler(IMediator mediator) : INotificationHandler<NotificationPlayerCharacterDied>
    {
        private IMediator _mediator = mediator;

        public Task Handle(NotificationPlayerCharacterDied notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
