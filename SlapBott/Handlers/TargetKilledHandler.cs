using MediatR;
using SlapBott.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Handlers
{

    //this occurs when a player kills their target they should receive rewards,
    //need to check the state object to get all the active participants,
    //give rewards reset states id's = 0, remove enemy from play (raidboss remove from region ect)
    public class TargetKilledHandler(IMediator mediator) : INotificationHandler<NotificationTargetKilled>
    {
        private IMediator _mediator = mediator;
        public Task Handle(NotificationTargetKilled notification, CancellationToken cancellationToken)
        {
            
            throw new NotImplementedException();
        }
    }
}
