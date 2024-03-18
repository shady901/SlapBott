using Discord;
using Discord.Interactions;
using InteractionFramework;
using SlapBott.Services.Contracts;
using SlapBott.Services.Implmentations;


namespace SlapBott.Commands
{
    public class CreateCharacter : InteractionModuleBase<SocketInteractionContext>
    {
        private InteractionHandler? _handler;
        private RegistrationService _registrationService;
        public InteractionService Commands { get; set; }
        
        public CreateCharacter(InteractionHandler? handler,RegistrationService registrationService) 
        {
            _handler = handler;
            _registrationService = registrationService;
            // _characterCreationService = characterCreationService;
        }




        [SlashCommand("createnewcharacter", description: "Creates a New Character", ignoreGroupNames: false, runMode: RunMode.Async)]
        public async Task JoinBotAsync()
        {

            try
            {
                if (_registrationService.CheckIfPlayerExists(Context.User.Id))
                {
                    await Context.Interaction.RespondAsync(embed: BuilderReplies.ChoseRaceEmbed(), components: BuilderReplies.GetChoseRaceMessageComponent());

                }
                else 
                {
                    await Context.Interaction.RespondAsync("U have not Joined the Bot");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
       


    }
}
