using MediatR;
using SlapBott.Notifications;
using SlapBott.RequestHandlers;
using SlapBott.Requests;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Handlers
{
    public class SelectMenuUsedSkillHandler(IMediator mediator) : INotificationHandler<SelectMenuUsedSkillNotification>
    {
        private readonly IMediator _mediator;
        public async Task Handle(SelectMenuUsedSkillNotification notification, CancellationToken cancellationToken)
        {
            var DropDown = notification;
            string[] customId = DropDown.messageComponent.Data.CustomId.Split(' ');
            int enemyId = 0;
            if (customId.Length >=2)
            {
               enemyId = int.Parse(customId[1]);
            }
            EnemyDto enemyDto =  await _mediator.Send(new RequestGetEnemyCharacter(enemyId));
            RegistrationDto registrationDto = await _mediator.Send(new GetRegistration(notification.messageComponent.User.Id));
            PlayerCharacterDto characterDto = await _mediator.Send(new RequestGetExistingCharacterOrNew(notification.messageComponent.User.Id,registrationDto.ActiveCharacterId));

        }
    }
}
