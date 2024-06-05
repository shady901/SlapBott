using MediatR;
using SlapBott.ItemProject.Items;
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

    //this occurs when a player kills their target they should receive rewards,
    //need to check the state object to get all the active participants,
    //give rewards reset states id's = 0, remove enemy from play (raidboss remove from region ect)
    public class TargetKilledHandler(IMediator mediator, ItemService itemService) : INotificationHandler<NotificationTargetKilled>
    {
        private IMediator _mediator = mediator;
        private ItemService _itemService = itemService;
        public async Task Handle(NotificationTargetKilled notification, CancellationToken cancellationToken)
        {
            var exp = GetPercentExpFromExp(notification.EnemyDto.CharExp);
            notification.PlayerCharacterDto.AddExp(exp);





            //need to check drop table for stuff before getting item type ect
            Item? Item = _itemService.GetItemObjectBySeed(droppedLevel: notification.EnemyDto.Level) as Item;



            //save item push notification saying player got item display stats
            if (Item != null)
            {
                notification.PlayerCharacterDto.Inventory.SaveItemToBag(new Data.Models.Item() { Seed = Item.Seed });
            }

            await _mediator.Send(new RequestSavePlayerCharacterDto(notification.PlayerCharacterDto));
           await  notification.MessageComponent.FollowupAsync($"You Killed {notification.EnemyDto.Name}\nYou Gained {exp} EXP\nYou Gained Item('s): {Item.Name}");
        }











        //get exp from enemy and get a % of it 
        private ulong GetPercentExpFromExp(ulong exp)
        {
            Random random = new Random();

            return (ulong)(exp * (double)(random.Next(1 , 6) / 100));
        }

       
    }
}
