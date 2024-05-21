using Discord;
using Discord.Interactions;
using Discord.Rest;
using Discord.WebSocket;
using InteractionFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Services.Implmentations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SlapBott.Commands
{
    public class InitializeBot : InteractionModuleBase<SocketInteractionContext>
    {
        private InteractionHandler? _handler;
        public InteractionService Commands { get; set; }
        private DiscordGuildService _discordGuildService;
        public InitializeBot(InteractionHandler handler,DiscordGuildService discordGuildService)
        {
            _discordGuildService = discordGuildService;
            _handler = handler;
          
        }

        [SlashCommand("setupbot", description: "Sets Up the bot and generates channels", ignoreGroupNames: false, runMode: RunMode.Async)]
        public async Task InitializeBotCommand()
        {
            ulong discordGuildId = Context.Guild.Id;
            SocketGuildUser? a = Context.User as SocketGuildUser;
            bool IsAdmin = a.GuildPermissions.Administrator;
            if (!IsAdmin)
            {
               await RespondAsync("Your Not An Admin You Cannot Use This Command"); 
               return;
            }




            

            IRole Role = await GetOrCreateRole();
            var botGuildUser = Context.Guild.GetUser(Context.Client.CurrentUser.Id);

            // Assign the role to the bot
            await (botGuildUser as IGuildUser).AddRoleAsync(Role);

            ICategoryChannel categoryChannel = await GetOrCreateCategoryChannelAsync(Role);
           
             List<ITextChannel> ExistingChannels = (List<ITextChannel>)CheckCategoryChannelForChannels(categoryChannel);
           
         
            Dictionary<Regions,ulong> channels= CreateChannels(GetChannelProperties(categoryChannel.Id),ExistingChannels);
            _discordGuildService.SaveGuild(new DiscordGuild() {GuildId = discordGuildId,CategoryId=categoryChannel.Id,ConfiguredChannels=channels });
            await RespondAsync("Channels And Role Permissions Setup");
        }

       
        private IEnumerable<ITextChannel> CheckCategoryChannelForChannels(ICategoryChannel categoryChannel)
        {
            var channelsInCategory = Context.Guild.Channels
             .OfType<ITextChannel>() // Filter to message channels only
                 .Where(channel => channel.CategoryId == categoryChannel.Id).ToList();
            return channelsInCategory;
        }

        private TextChannelProperties GetChannelProperties(ulong categoryId)
        {
            TextChannelProperties regionChannelProperties = new TextChannelProperties();
            regionChannelProperties.CategoryId = categoryId;
            return regionChannelProperties;
        }
        private Dictionary<Regions,ulong> CreateChannels(TextChannelProperties textChannelProperties,List<ITextChannel>? ExistingTextChannels =null)
        {
            List<Regions> a = ((Regions[])Enum.GetValues(typeof(Regions))).ToList();

            Dictionary<Regions, ulong> Channels = new Dictionary<Regions, ulong>();
            if (ExistingTextChannels !=null)
            {
                foreach (var regions in a)
                {
                    var b = ExistingTextChannels.Where(x => x.Name == regions.ToString().ToLower()).FirstOrDefault();
                    if ( b!= null) 
                    {
                      
                        Channels.Add(regions, b.Id);
                    }
                    else 
                    {
                        Channels[regions] = Context.Guild.CreateTextChannelAsync(regions.ToString(), tcp => tcp.CategoryId = textChannelProperties.CategoryId).Result.Id;
                       
                    }
                }
            }           
            return Channels;
        }
        private async Task<ICategoryChannel> GetOrCreateCategoryChannelAsync(IRole role)
        {
            string categoryName = "SlapBott";
            ICategoryChannel? categoryChannel = Context.Guild.CategoryChannels.FirstOrDefault(c => c.Name == categoryName);

            if (categoryChannel == null)
            {
                categoryChannel = await Context.Guild.CreateCategoryChannelAsync(categoryName, properties =>
                {
                    properties.PermissionOverwrites = new List<Overwrite>
                    {
                        // Add permission overwrites for specific roles or users
                        new Overwrite(Context.Guild.EveryoneRole.Id, PermissionTarget.Role, new OverwritePermissions(viewChannel: PermValue.Deny)),
                        new Overwrite(role.Id,PermissionTarget.Role,new OverwritePermissions(viewChannel: PermValue.Allow)) 
                    };
                });
            }
            return categoryChannel;

        }
        private async Task<IRole> GetOrCreateRole()
        {
            
            string roleName = DiscordRole.SlapBottParticipant.ToString();
            IRole? existingRole = Context.Guild.Roles.FirstOrDefault(r => r.Name == roleName);
            if (existingRole == null)
            {
                existingRole = await Context.Guild.CreateRoleAsync(roleName);
            }
            return existingRole;
        }
    }
}
