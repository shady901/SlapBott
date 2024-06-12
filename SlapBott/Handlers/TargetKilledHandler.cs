using MediatR;
using SlapBott.Data.Models;
using SlapBott.ItemProject.Builders;
using SlapBott.ItemProject.Items;
using SlapBott.Notifications;
using SlapBott.RequestHandlers;
using SlapBott.Requests;
using SlapBott.Services;
using SlapBott.Services.Dtos;
using SlapBott.Services.Implmentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Handlers
{

    //this occurs when a player kills their target they should receive rewards,
    //need to check the state object to get all the active participants,
    //give rewards reset states id's = 0, remove enemy from play (raidboss remove from region ect)
    public class TargetKilledHandler(IMediator mediator, GearService gearService) : INotificationHandler<NotificationTargetKilled>
    {
        private IMediator _mediator = mediator;
        private GearService _gearService = gearService;
        public async Task Handle(NotificationTargetKilled notification, CancellationToken cancellationToken)
        {

           //get the combatstate from the enemy state
            CombatStateDto state = await GetCombatStateFromEnemyState(notification.EnemyDto.CombatStateId);
            //get a percent of exp from boss
            var exp = GetPercentExpFromExp(notification.EnemyDto.CharExp);
            //add the exp to each character
            GiveAllParticipatingPlayersExp(state.Characters,exp);
            //get the loot table


            GiveAllParticipatingPlayersLoot(state.Characters, notification.EnemyDto.LootTableDto);
            
           
            //save list of players
            //edit boss stuff to finish raid
            //post notifications to players/servers



          
            await _mediator.Send(new RequestSavePlayerCharacterDto(notification.PlayerCharacterDto));
           await  notification.MessageComponent.FollowupAsync($"You Killed {notification.EnemyDto.Name}\nYou Gained {exp} EXP\nYou Gained Item('s): {Gear.Name}");
        }

        private void GiveAllParticipatingPlayersLoot(ICollection<PlayerCharacterCombatStateDto> characters, LootTableDto LootTable)
        {

            

            foreach (var character in characters)
            {
               
                 character.Character.Inventory.SaveItemToBag(GetRandomItemFromLootTable(LootTable).Result);
            }
        }

        private async Task<EquipmentDto> GetRandomItemFromLootTable(LootTableDto lootTable)
        {
            
         return   await _mediator.Send(new RequestConvertToEquipmentFromLootTableItemDto(lootTable.RandomItemFromLootTable())); 
        }

        private void GiveAllParticipatingPlayersExp(ICollection<PlayerCharacterCombatStateDto> characters, ulong exp)
        {

            foreach (PlayerCharacterCombatStateDto character in characters)
            { 
                character.Character.AddExp(exp);
            
            }
        }

        //get the state from the state id
        private async Task<CombatStateDto> GetCombatStateFromEnemyState(int EnemyStateId)
        {
            EnemyCombatStateDto enemyCombatStateDto = await _mediator.Send(new RequestGetEnemyCombatState(EnemyStateId));
            return await _mediator.Send(new RequestCombatStateDto(enemyCombatStateDto.CombatStateId));

        }
        //get exp from enemy and get a % of it 
        private ulong GetPercentExpFromExp(ulong exp)
        {
            Random random = new Random();

            return (ulong)(exp * (double)(random.Next(1 , 6) / 100));
        }

      
      
    }
}
