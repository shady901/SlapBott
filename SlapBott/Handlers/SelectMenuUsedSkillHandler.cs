using Discord;
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
using System.Reactive;
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

            //getenemy
            EnemyDto enemyDto = await _mediator.Send(new RequestGetEnemyCharacter(enemyId));
            //getplayer
            PlayerCharacterDto characterDto = await _mediator.Send(new RequestGetExistingCharacterOrNew(notification.messageComponent.User.Id));
            //getskill player is using
            SkillDto usedSkillDto = await _mediator.Send(new RequestGetSkill(int.Parse(dropDownValue)));
            try
            {
                //player attack returning results object
                AttackResults<PlayerCharacterDto, EnemyDto> result = await _combatManager.Attack(usedSkillDto, characterDto, enemyDto);
                //initialise enemy result object
                AttackResults<EnemyDto, PlayerCharacterDto> enemyAttackResult = new AttackResults<EnemyDto, PlayerCharacterDto>(enemyDto, characterDto);

                //default skill dropdown
                MessageComponent e = BuilderReplies.CreateSkillsDropDown(_skillService.GetSkillCollectionByIds(characterDto.Skills).ToList(),
                             enemyId, Enums.SelectMenuCommands.UseSkill);
                INotification method = null;
                //if your attack kills enemy
                if (result.TargetKilled)
                {
                    e = null;
                method = new NotificationTargetKilled(characterDto, enemyDto , notification.messageComponent);
                }                
                else
                {
                    //if enemy not dead it attacks 
                    enemyAttackResult = await _mediator.Send(new RequestAttackBack(characterDto, enemyDto));
                    characterDto = enemyAttackResult.Receiver;
                    enemyDto = enemyAttackResult.Sender;

                    //if enemy attack kills you
                    if (enemyAttackResult.TargetKilled)
                    {
                        e = null;
                        method = new NotificationPlayerCharacterDied(characterDto);
                    }
                }
                //save the objects
                characterDto = await _mediator.Send(new RequestSavePlayerCharacterDto(characterDto));
                enemyDto = await _mediator.Send(new RequestSaveEnemyDto(enemyDto));



                //reply
                await notification.messageComponent.RespondAsync(
                     embed:
                     BuilderReplies.EmbedTurnResults(result, enemyAttackResult),
                     components:
                      e??null,
                    ephemeral: true);

                //mediate result if any
                if (method != null)
                {
                    await _mediator.Publish(method);
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        


       
    }
}
