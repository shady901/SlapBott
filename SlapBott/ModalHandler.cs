using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using SlapBott.Data.Contracts;
using SlapBott.Data.Models;

namespace SlapBott.Services.Implmentations
{
    public class ModalHandler: IModalHandler
    {
        public PlayerCharacterService? _playerCharacterService;
        public ModalHandler(PlayerCharacterService? playerCharacterService)
        {
            _playerCharacterService = playerCharacterService;
        }

     

        public string HandleSubmittedModal(SocketModal modal)
        {
            

            if (modal.Data.CustomId !=null)
            {
                 string customId = modal.Data.CustomId;

                switch (customId)
                {
                    case "New Character":
                        return IsCreateCharacter(modal);
                    //case "someCustomId2":
                    //    break;
                    default:
                        return "ERROR: ModalHandler couldnt find customID";
                }
            }

            return "ERROR: ModalHandler CustomId Is NUll";
        }

        public string IsCreateCharacter(SocketModal modal)
        {
            List<SocketMessageComponentData> components = modal.Data.Components.ToList();
            // _playerCharacterService.CreateCharacter(modal);
           string Race = components
                .First(x => x.CustomId == "Race_name").Value;
            string Bio = components
                .First(x => x.CustomId == "Your_description").Value;



            PlayerCharacterDto newChar = new PlayerCharacterDto() { };
            return "Your Character has been created";
        }

    }
}
