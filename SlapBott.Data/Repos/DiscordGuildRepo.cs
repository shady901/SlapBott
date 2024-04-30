using SlapBott.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Repos
{
    public class DiscordGuildRepo: Repo<DiscordGuild>
    {
        public DiscordGuildRepo(SlapbottDbContext dBContext) : base(dBContext)
        {
        }

        public DiscordGuild SaveGuild(DiscordGuild discordGuild)
        {
           return AddOrUpdateEntity(discordGuild);
        }
    }
}
