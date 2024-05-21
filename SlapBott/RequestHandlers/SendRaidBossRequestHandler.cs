using MediatR;
using SlapBott.Data.Enums;
using SlapBott.Notifications;
using SlapBott.Requests;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualBasic;
using Discord;
using Discord.WebSocket;
using SlapBott.Services.Notifactions;

namespace SlapBott.RequestHandlers
{
    public class SendRaidBossRequestHandler(IMediator mediator, SlapbottDiscordSocketClient discordClient) : IRequestHandler<SendRaidBossRequest, bool>
    {
        private IMediator _mediator = mediator;
        private readonly SlapbottDiscordSocketClient _discordClient = discordClient;

        public async Task<bool> Handle(SendRaidBossRequest notification, CancellationToken cancellationToken)
        {
            var Guilds = await _mediator.Send(new GetAllGuilds());
            foreach (var guild in Guilds)
            {
                ulong GuildId = guild.GuildId;
                ulong CategoryId = guild.CategoryId;
                Dictionary<Regions, ulong> RegionChannels = guild.ConfiguredChannels;
                var channel = _discordClient.GetGuild(GuildId)?.GetTextChannel(RegionChannels[notification.Region]); // Replace 'YourRegion' with the appropriate region enum value
                if (channel != null)
                {
                    // message content needs buttons and stuff for interactibility
                    var messageContent = $"Raid notification: {notification.Component.Name}"; // Example message content
                    try
                    {
                        await channel.SendMessageAsync(messageContent);

                    }
                    catch (Exception x)
                    {

                        Console.WriteLine(x.Message);
                    }
                   
                }
            }
            return true;
        }

        
    }
}
