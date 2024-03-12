using Discord;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using SlapBott.Services.Implmentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott
{
    public class SelectMenuHandler
    {
        private PlayerCharacterService? _playerCharacterService;

        public SelectMenuHandler(PlayerCharacterService? playerCharacterService)
        {
            _playerCharacterService = playerCharacterService;
        }

        public void HandleSubmittedSelectMenu(SocketMessageComponent arg)
        {
            List<string> Splitarg = arg.Data.CustomId.ToLower().Trim().Split('_').ToList();
          
            string? condition = Splitarg.FirstOrDefault();
            switch (condition)
            {
                case "createcharacter":
                    CreatingCharacter(arg);
                    break;
                default:
                    break;
            }
        }

        public async void CreatingCharacter(SocketMessageComponent arg)
        {
            string? menuVarible = arg.Data.Values.ToString();

           
            
        }



    }
}
