using Discord;
using Discord.Interactions;
using InteractionFramework;
using Microsoft.EntityFrameworkCore;
using SlapBott.Data.Enums;
using SlapBott.Services.Implmentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Commands
{
    public class InitializeBot : InteractionModuleBase<SocketInteractionContext>
    {
        private InteractionHandler? _handler;
        public InteractionService Commands { get; set; }

        public InitializeBot(InteractionHandler handler, RegistrationService registrationService)
        {
            _handler = handler;
          
        }

        [SlashCommand("setupbot", description: "Sets Up the bot and generates channels", ignoreGroupNames: false, runMode: RunMode.Async)]
        public async Task InitializeBotCommand()
        {
           
           await Context.Guild.CreateRoleAsync("SlapBottParticipant");
           ulong categoryId = Context.Guild.CreateCategoryChannelAsync("SlapBott").Result.GuildId;
            
            await Context.Guild.CreateTextChannelAsync(Regions.BadLands.ToString(), tcp => tcp.CategoryId = categoryId); 

        }
    }
}
