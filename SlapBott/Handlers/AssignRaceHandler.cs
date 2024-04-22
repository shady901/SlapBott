using MediatR;
using SlapBott.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SlapBott.Handlers
{
    internal class AssignRaceHandler(IMediator mediator) : INotificationHandler<AssignRaceNotification>
    {
        public IMediator Mediator { get; } = mediator;

        public Task Handle(AssignRaceNotification notification, CancellationToken cancellationToken)
        {
            var Character = Mediator.Send();
            // get charact
            // assign race = data
            // save it


            var embed = BuilderReplies.ChoseRaceEmbed(data);
            notification.Component.RespondAsync(embed);

            // send response(em,notifcation.RespondAsync)

            return Task.CompletedTask;
        }
    }
}
