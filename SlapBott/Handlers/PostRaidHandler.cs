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

namespace SlapBott.Handlers
{
    public class PostRaidHandler(IMediator mediator, DiscordSocketClient discordClient) : INotificationHandler<PostRaidNotification>
    {
        private IMediator _mediator { get; } = mediator;
        private readonly DiscordSocketClient _discordClient = discordClient;

        public async Task Handle(PostRaidNotification notification, CancellationToken cancellationToken)
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
                    await channel.SendMessageAsync(messageContent);
                    
                }
            }
        }
    }
}
