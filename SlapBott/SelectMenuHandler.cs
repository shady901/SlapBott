using Discord;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using SlapBott.Data.Models;
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
        private PlayerCharacterDto? _playerCharacterDto;
        public SelectMenuHandler(PlayerCharacterService? playerCharacterService, RegistrationService? registrationService)
        {
            _playerCharacterService = playerCharacterService;
            _registrationService = registrationService;
        }

        public void HandleSubmittedSelectMenu(SocketMessageComponent arg)
        {
            List<string> Splitarg = arg.Data.CustomId.ToLower().Trim().Split('_').ToList();
          
            string? condition = Splitarg.FirstOrDefault();
            _playerCharacterDto = SetupBaseCharacterDto(arg.User.Id);
            switch (condition)
            {
                case "createcharacter":
                    ÄssigningRace(arg,Splitarg[1]);
                    break;
                default:
                    break;
            }
        }

        public void ÄssigningRace(SocketMessageComponent arg,string characterStat)
        {
            if (characterStat=="selectrace")
            {
                string race = arg.Data.Values.First();
                _playerCharacterDto.Race.Name = (Races)Enum.Parse(typeof(Races), race);
                //should be getting matching class from database and assigning it to the dto for saving
                //character.CharacterClass = new CharacterClass();
                //return character;
                arg.RespondAsync(embed: BuilderReplies.RaceSelectedReply(arg.Data.Values.First()));
            }
 
        }

        public PlayerCharacterDto SetupBaseCharacterDto(ulong argId)
        {
            PlayerCharacterDto character = new PlayerCharacterDto()
                  .FromCharacter(
                 _playerCharacterService.GetPlayerCharacterByDiscordIdOrNew(
             argId
                 ));
            return character;
            
        }


    }
}
