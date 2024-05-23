using MediatR;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Notifications;
using SlapBott.Requests;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SlapBott.Handlers
{
    public class AssignRaceHandler(IMediator mediator) : INotificationHandler<AssignRaceNotification>
    {
        public IMediator Mediator { get; } = mediator;

        public async Task Handle(AssignRaceNotification component, CancellationToken cancellationToken)
        {
            var User = component.Component.User;
            var Data = component.Component.Data;
            PlayerCharacterDto Character = await Mediator.Send(new RequestGetExistingCharacterOrNew(User.Id));           
            Character.SelectedRace = (Races)Enum.Parse(typeof(Races), Data.Values.First());          
            await Mediator.Send(new RequestSavePlayerCharacterDto(Character));
            
            var embed = BuilderReplies.RaceSelectedReply(Data.Values.First());
            var dropDown= BuilderReplies.GetChoseClassMessageComponent();
            await component.Component.RespondAsync(embed:embed,components:dropDown);            
        }
    }
}
