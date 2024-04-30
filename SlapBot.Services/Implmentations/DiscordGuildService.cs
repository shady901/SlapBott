using SlapBott.Data.Models;
using SlapBott.Data.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Implmentations
{
    public class DiscordGuildService
    {
        private DiscordGuildRepo _discordGuildRepo;
        public DiscordGuildService(DiscordGuildRepo discordGuildRepo) 
        { 
            _discordGuildRepo = discordGuildRepo;
        }

        public void SaveGuild(DiscordGuild discordGuild)
        {
            _discordGuildRepo.SaveGuild(discordGuild);
        }
    }
}
