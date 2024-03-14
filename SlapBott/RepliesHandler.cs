using Discord;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Services.Dtos;
using SlapBott.Services.Implmentations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott
{
    public class RepliesHandler
    {
        private PlayerCharacterService? _playerCharacterService;
        private RegistrationService? _registrationService;
        private PlayerCharacterDto? _playerCharacterDto;
        public RepliesHandler(PlayerCharacterService? playerCharacterService, RegistrationService? registrationService)
        {
            _playerCharacterService = playerCharacterService;
            _registrationService = registrationService;
        }

        public void HandleSubmittedSelectMenu(SocketMessageComponent arg)
        {
            List<string> Splitarg = arg.Data.CustomId.ToLower().Trim().Split('_').ToList();
          
            string? condition = Splitarg.FirstOrDefault();
            _playerCharacterDto = SetupBaseCharacterDto(arg.User.Id);
            if (condition == "createcharacter") 
            {
                switch (Splitarg[1])
                {
                    case "selectrace":
                        AssigningRace(arg);
                        break;
                    case "selectclass":
                        AssigningClass(arg);
                        break;
                    default:
                        break;
                }
            }
           
        }
        public string HandleSubmittedModal(SocketModal modal)
        {


            if (modal.Data.CustomId != null)
            {
                string customId = modal.Data.CustomId;

                switch (customId)
                {
                    case "createcharacter_namedescription":
                         AssignCharacterNameDescription(modal);
                        break;
                    //case "someCustomId2":
                    //    break;
                    default:
                        return "ERROR: ModalHandler couldnt find customID";
                }
            }

            return "ERROR: ModalHandler CustomId Is NUll";
        }

        public void AssignCharacterNameDescription(SocketModal modal)
        {
            if (_playerCharacterDto!=null)
            {
                var components = modal.Data.Components.ToList();
                _playerCharacterDto.Name = components.First(x => x.CustomId == "character_name").Value;
                _playerCharacterDto.Description = components.First(x => x.CustomId == "character_description").Value;
                modal.RespondAsync(embed: BuilderReplies.ReplyCreatedCompleteEmbed(
                    _playerCharacterDto.Name,
                    _playerCharacterDto.Description,
                    _playerCharacterDto.SelectedRace.ToString(),
                    _playerCharacterDto.SelectedClass.ToString()
                    ),ephemeral : true);
            }
            modal.RespondAsync("Something went Wrong");
        }
        private void AssigningClass(SocketMessageComponent arg)
        {
            string cClass = arg.Data.Values.First();
            try
            {
                _playerCharacterDto.SelectedClass = (Classes)Enum.Parse(typeof(Classes), cClass);
                arg.RespondWithModalAsync(BuilderReplies.ModalCharacterNameDescription());
            }
            catch (Exception ex)
            {
                arg.RespondAsync("Couldnt Assign A Class" + ex.Message);
            }

        }

        public void AssigningRace(SocketMessageComponent arg)
        {           
            string race = arg.Data.Values.First();
            try
            {
              //  Races a = (Races)Enum.Parse(typeof(Races), race);
                _playerCharacterDto.SelectedRace = (Races)Enum.Parse(typeof(Races), race);
                arg.RespondAsync(embed: BuilderReplies.RaceSelectedReply(arg.Data.Values.First()), components: BuilderReplies.GetChoseClassMessageComponent());
            }
            catch (Exception ex)
            {
                arg.RespondAsync("Couldnt Assign A Race"+ ex.Message);
                
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
