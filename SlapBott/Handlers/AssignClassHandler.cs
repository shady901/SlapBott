using MediatR;
using SlapBott.Data.Enums;
using SlapBott.Notifications;
using SlapBott.Requests;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Handlers
{
    public class AssignClassHandler(IMediator mediator) : INotificationHandler<AssignClassNotification>
    {
        public IMediator Mediator { get; } = mediator;

        public async Task Handle(AssignClassNotification component, CancellationToken cancellationToken)
        {
            var User = component.Component.User;
            var Data = component.Component.Data;
            PlayerCharacterDto Character = await Mediator.Send(new RequestGetExistingCharacterOrNew(User.Id,Temp:true));
            Character.SelectedClass = (Classes)Enum.Parse(typeof(Classes), Data.Values.First());
            Character.Skills.Add(1);
            await Mediator.Send(new RequestSavePlayerCharacterDto(Character));
            var Modal = BuilderReplies.ModalCharacterNameDescription();
            await component.Component.RespondWithModalAsync(Modal);
        }
    }
}
