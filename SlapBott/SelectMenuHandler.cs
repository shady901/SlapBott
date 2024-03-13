using Discord;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using SlapBott.Services.Dtos;
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
        private RegistrationService? _registrationService;
        public SelectMenuHandler(PlayerCharacterService? playerCharacterService, RegistrationService? registrationService)
        {
            _playerCharacterService = playerCharacterService;
            _registrationService = registrationService;
        }

        public void HandleSubmittedSelectMenu(SocketMessageComponent arg)
        {
            List<string> Splitarg = arg.Data.CustomId.ToLower().Trim().Split('_').ToList();
          
            string? condition = Splitarg.FirstOrDefault();
            switch (condition)
            {
                case "createcharacter":
                    CreatingCharacter(arg, Splitarg[1]);
                    break;
                default:
                    break;
            }
        }

        public async void CreatingCharacter(SocketMessageComponent arg,string characterStat)
        {
            if (characterStat=="selectclass")
            {
               PlayerCharacterDto charcter = new PlayerCharacterDto()
                    .FromCharacter(
                   _playerCharacterService.GetCharacterByID(
                   _registrationService.GetActiveTempCharacterId(arg.User.Id)));
                
            }




        }



    }
}
