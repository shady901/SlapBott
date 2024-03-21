using Discord;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Services.Dtos;
using SlapBott.Services.Implmentations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SlapBott
{
    public class RepliesHandler
    {
        private PlayerCharacterService? _playerCharacterService;
        private RegistrationService? _registrationService;
        private PlayerCharacterDto? _playerCharacterDto;
        private PlayerCharacter? _playerCharacter;
        private Registration? _registration;
        private SkillService? _skillService;
        public RepliesHandler(PlayerCharacterService? playerCharacterService, RegistrationService? registrationService, SkillService? skillService)
        {
            _playerCharacterService = playerCharacterService;
            _registrationService = registrationService;
            _skillService = skillService;
        }

        public void HandleSubmittedSelectMenu(SocketMessageComponent arg)
        {
            List<string> Splitarg = arg.Data.CustomId.ToLower().Trim().Split('_').ToList();          
            string? condition = Splitarg.FirstOrDefault();
            SetTheRegistrationfromDiscordId(arg.User.Id);
            if (_registration == null)
            {
                arg.RespondAsync("you have not joined the bot");
            }
            else
            {
                if (condition == "createcharacter")
                {
                    SelectMenuCreateCharacter(Splitarg[1],arg);

                }
            }
        }
        
        public void HandleSubmittedModal(SocketModal modal)
        {
            SetTheRegistrationfromDiscordId(modal.User.Id);
            SetupBaseCharacterDto(modal.User.Id);
            if (_registration == null)
            {
                modal.RespondAsync("you have not joined the bot");
            }
            else 
            {
                if (modal.Data.CustomId != null)
                {
                    string customId = modal.Data.CustomId;

                    switch (customId)
                    {
                        case "createcharacter_namedescription":
                            AssignCharacterNameDescription(modal);
                            break;
                        default:
                            modal.RespondAsync("ERROR: ModalHandler couldnt find customID");
                            break;
                    }
                }
                else
                {
                    modal.RespondAsync("ERROR: ModalHandler CustomId Is NUll");
                }
            }

        }
        private void SelectMenuCreateCharacter(string condition, SocketMessageComponent arg)
        {
            SetupBaseCharacterDto(arg.User.Id);
            switch (condition)
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
        private void AssignCharacterNameDescription(SocketModal modal)
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
                SaveAndCompleteCreation();
             
            }
            else
            {
                modal.RespondAsync("Something went Wrong");

            }
        }
     

        private void AssigningRace(SocketMessageComponent arg)
        {
        
            string race = arg.Data.Values.First();
            try
            {
                
              //  Races a = (Races)Enum.Parse(typeof(Races), race);
                _playerCharacterDto.SelectedRace = (Races)Enum.Parse(typeof(Races), race);
                SaveCharacter();
                arg.RespondAsync(embed: BuilderReplies.RaceSelectedReply(arg.Data.Values.First()), components: BuilderReplies.GetChoseClassMessageComponent(), ephemeral:true);
            }
            catch (Exception ex)
            {
                arg.RespondAsync("Couldnt Assign A Race "+ ex.Message);
                
            }            
 
        }

        private void SetupBaseCharacterDto(ulong argId)
        {
            _playerCharacterDto = new();
            _playerCharacter = new();
            _playerCharacter = _playerCharacterService.GetTempPlayerCharacterByDiscordIdOrNew(argId, _registration.Id);
            _playerCharacterDto = new PlayerCharacterDto()
                  .FromCharacter(_playerCharacter);
        }
        private void SaveCharacter()
        {
             _playerCharacterService.SaveCharacter(_playerCharacterDto.ToCharacter(_playerCharacter));
        }
        private void SetTheRegistrationfromDiscordId(ulong DiscordId)
        {
            _registration = _registrationService.GetUserByDiscordId(DiscordId);
            
        }
        private void AssigningClass(SocketMessageComponent arg)
        {
            
            string cClass = arg.Data.Values.First();
            try
            {
                _playerCharacterDto.SelectedClass = (Classes)Enum.Parse(typeof(Classes), cClass);
                SaveCharacter();
                arg.RespondWithModalAsync(BuilderReplies.ModalCharacterNameDescription());
            }
            catch (Exception ex)
            {
                arg.RespondAsync("AssigningClass Meth Failed" + ex.Message);
            }

        }
        private void SaveAndCompleteCreation()
        { 
            _playerCharacterDto.IsTemp = false;
            _registration.ActiveCharacterId = _playerCharacterDto.Id;
            _playerCharacterDto.SetCharacerRaceBaseStats();
            _playerCharacterDto.SetCharacerClassBaseStats();
            SetStartingSkills();
            //generate starting stats and equiment and other starting data


            try
            {
                SaveCharacter();
                _registrationService.SaveRegistration(_registration);
                
            }
            catch (Exception ex)
            {

               Console.WriteLine("(CompleteCreation)Failed too Save Character Or register "+ex);
            }
          
        }
        private void SetStartingSkills()
        {
            if (_playerCharacterDto.Skills is null)
            {
                _playerCharacterDto.Skills = new List<SkillDto> {
                    { new SkillDto().FromSkill(_skillService.GetSkillById(1)) }
            };
            }
        }
    }
}
