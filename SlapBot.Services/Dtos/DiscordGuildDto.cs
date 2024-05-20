using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
    public class DiscordGuildDto
    {
        public int Id { get; set; }
        public ulong GuildId { get; set; }
        public ulong CategoryId { get; set; }
        public Dictionary<Regions, ulong> ConfiguredChannels { get; set; }



        public DiscordGuildDto FromGuild(DiscordGuild discordGuild)
        {
            Id = discordGuild.Id;
            GuildId = discordGuild.GuildId;
            CategoryId = discordGuild.CategoryId;
            ConfiguredChannels = discordGuild.ConfiguredChannels;
            return this;
        }

        public DiscordGuild ToGuild(DiscordGuild discordGuild)
        {
           
            discordGuild.GuildId =GuildId;
            discordGuild.CategoryId = CategoryId;
            discordGuild.ConfiguredChannels = ConfiguredChannels;
            return discordGuild;
        }

    }
}
