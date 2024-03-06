using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using SlapBott.Services.Implmentations;
using SlapBott.Services.Contracts;
namespace SlapBott.Commands
{
    public class CreateCharacter : InteractionModuleBase<SocketInteractionContext>
    {
        private IPlayerCharacterCreation _characterCreationService;
        public CreateCharacter(IPlayerCharacterCreation characterCreationService) 
        {
                _characterCreationService = characterCreationService;
        }






    }
}
