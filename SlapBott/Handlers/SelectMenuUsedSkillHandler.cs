using MediatR;
using SlapBott.Data.Models;
using SlapBott.Notifications;
using SlapBott.RequestHandlers;
using SlapBott.Requests;
using SlapBott.Services.Dtos;
using SlapBott.Services.Implmentations;
using SlapBott.Services.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Handlers
{
    public class SelectMenuUsedSkillHandler(IMediator mediator, CombatManager combatManager,SkillService skillService) : INotificationHandler<SelectMenuUsedSkillNotification>
    {
        private IMediator _mediator = mediator;
        private CombatManager _combatManager = combatManager;
        private SkillService _skillService = skillService;
        public async Task Handle(SelectMenuUsedSkillNotification notification, CancellationToken cancellationToken)
        {
            var dropDown = notification;
            string[] customId = dropDown.messageComponent.Data.CustomId.Split(' ');
            string dropDownValue = dropDown.messageComponent.Data.Values.First();
            int enemyId = customId.Length >= 2 ? int.Parse(customId[1]) : 0;

            EnemyDto enemyDto = await _mediator.Send(new RequestGetEnemyCharacter(enemyId));
            if(enemyDto.Stats.Health == 0)
            {
                enemyDto.Stats.Health = 100;
                enemyDto.Stats.MaxHealth = 100;
            }

            PlayerCharacterDto characterDto = await _mediator.Send(new RequestGetExistingCharacterOrNew(notification.messageComponent.User.Id));
            characterDto.Stats.Strength = 50;
            SkillDto usedSkillDto = await _mediator.Send(new RequestGetSkill(int.Parse(dropDownValue)));
            try
            {
                AttackResults<PlayerCharacterDto, EnemyDto> result = await _combatManager.Attack(usedSkillDto, characterDto, enemyDto);

                AttackResults<EnemyDto, PlayerCharacterDto> enemyAttackResult = new AttackResults<EnemyDto, PlayerCharacterDto>(enemyDto, characterDto);
                if (enemyDto.Stats.Health > 0)
                {
                    enemyAttackResult = await _mediator.Send(new RequestAttackBack(characterDto, enemyDto));
                    characterDto = enemyAttackResult.Receiver;
                    enemyDto = enemyAttackResult.Sender;
                }


                await notification.messageComponent.RespondAsync(
                    embed: BuilderReplies.EmbedTurnResults(
                        result, enemyDto, enemyAttackResult), 
                    components: 
                    BuilderReplies.CreateSkillsDropDown(
                            _skillService.GetSkillCollectionByIds(characterDto.Skills).ToList(), 
                            enemyId, Enums.SelectMenuCommands.UseSkill
                        ),
            ephemeral: true);


                characterDto = await _mediator.Send(new RequestSavePlayerCharacterDto(characterDto));
                //enemyDto = await _mediator.Send(new RequestSaveEnemyDto(enemyDto));
                

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
