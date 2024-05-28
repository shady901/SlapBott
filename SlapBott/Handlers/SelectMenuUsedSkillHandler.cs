using MediatR;
using SlapBott.Notifications;
using SlapBott.RequestHandlers;
using SlapBott.Requests;
using SlapBott.Services.Dtos;
using SlapBott.Services.Implmentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Handlers
{
    public class SelectMenuUsedSkillHandler(IMediator mediator, CombatManager combatManager) : INotificationHandler<SelectMenuUsedSkillNotification>
    {
        private IMediator _mediator = mediator;
        private CombatManager _combatManager = combatManager;
        public async Task Handle(SelectMenuUsedSkillNotification notification, CancellationToken cancellationToken)
        {
            var dropDown = notification;
            string[] customId = dropDown.messageComponent.Data.CustomId.Split(' ');
            var dropDownValue = dropDown.messageComponent.Data.Values.First();
            int enemyId = 0;
            if (customId.Length >=2)
            {
               enemyId = int.Parse(customId[1]);
            }
            EnemyDto enemyDto =  await _mediator.Send(new RequestGetEnemyCharacter(enemyId));
            PlayerCharacterDto characterDto = await _mediator.Send(new RequestGetExistingCharacterOrNew(notification.messageComponent.User.Id));

            SkillDto UsedSkillDto = await _mediator.Send(new RequestGetSkill(int.Parse(dropDownValue)));
            _combatManager.Attack<>(UsedSkillDto, characterDto, enemyDto);
            var Dmg = _combatManager.CalcAndApplyDamage(UsedSkillDto,characterDto,enemyDto);
            await notification.messageComponent.RespondAsync($"Result:\n Damage: {Dmg}");
            //check if object died
        }
    }
}
