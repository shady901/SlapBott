using MediatR;
using SlapBott.Data.Models;
using SlapBott.Requests;
using SlapBott.Services.Dtos;
using SlapBott.Services.Implmentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.RequestHandlers
{
    public class GetAllGuildsHandler(DiscordGuildService discordGuildService) : IRequestHandler<GetAllGuilds, IEnumerable<DiscordGuildDto>>
    {
        private DiscordGuildService _discordGuildService = discordGuildService;

        public Task<IEnumerable<DiscordGuildDto>> Handle(GetAllGuilds request, CancellationToken cancellationToken)
        {
            List<DiscordGuildDto> guilds = new();
            foreach (var guild in _discordGuildService.GetAllGuilds())
            {
                guilds.Add(new DiscordGuildDto().FromGuild(guild));
            }

            return Task.FromResult<IEnumerable<DiscordGuildDto>>(guilds);
        }
    }
}
