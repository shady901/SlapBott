using Discord.Interactions;
using InteractionFramework;
using SlapBott.ItemProject.Contracts;
using SlapBott.ItemProject.Items;
using SlapBott.Services.Implmentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Commands
{
    public class GenerateItem : InteractionModuleBase<SocketInteractionContext>
    {
        private InteractionHandler? _handler;
        public InteractionService Commands { get; set; }
        private ItemService _itemService;
        public GenerateItem(ItemService itemService, InteractionHandler handler)
        {
            _handler = handler;
            _itemService = itemService;
        }


        [SlashCommand("generateitem", description: "Generates Items", ignoreGroupNames: false, runMode: RunMode.Async)]
        public async Task CreateNewCharacterAysnc()
        {
            var UserId = Context.User.Id;
            //var itemObject = _itemService.GetItemObjectBySeed();
            //try
            //{
            //    if (itemObject is Weapon weapon)
            //    {
            //        await Context.Interaction.RespondAsync(embed:BuilderReplies.DisplayWeapon(weapon));
                   
            //    }
            //    if (itemObject is Armor armor)
            //    {
            //        await Context.Interaction.RespondAsync(embed: BuilderReplies.DisplayArmor(armor));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }


    }
}
