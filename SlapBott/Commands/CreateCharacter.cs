using Discord.Interactions;
using SlapBott.Services.Contracts;
using SlapBott.Services.Implmentations;


namespace SlapBott.Commands
{
    public class CreateCharacter : InteractionModuleBase<SocketInteractionContext>
    {
        private IPlayerCharacterCreation _characterCreationService;
        public CreateCharacter(IPlayerCharacterCreation characterCreationService) 
        {
                _characterCreationService = characterCreationService;
        }




        [SlashCommand("CreateCharacter", description: "Creates a New Character", ignoreGroupNames: false, runMode: RunMode.Async)]
        public async Task JoinBotAsync()
        {
           
            string msg = _characterCreationService.CreateCharacter(Context.User.Id);

            try
            {
                await RespondAsync(msg);
            }
            catch (Exception ex)
            {

            }


        }


    }
}
