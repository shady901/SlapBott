using SlapBott.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Models
{
    public class DiscordGuild
    {
        public int Id { get; set; }
        public ulong GuildId { get; set; }
        public Dictionary<Regions,ulong> ConfiguredChannels { get; set; } 

    }
}
