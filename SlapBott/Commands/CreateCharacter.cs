using Discord.Interactions;
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
