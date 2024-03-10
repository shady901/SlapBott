using Discord;
using Discord.Interactions;
using InteractionFramework;
using SlapBott.Services.Contracts;
using SlapBott.Services.Implmentations;


namespace SlapBott.Commands
{
    public class CreateCharacter : InteractionModuleBase<SocketInteractionContext>
    {
        // private IPlayerCharacterCreation? _characterCreationService;
        private InteractionHandler _handler;
        public InteractionService Commands { get; set; }
        public CreateCharacter(InteractionHandler handler) 
        {
            _handler = handler;
               // _characterCreationService = characterCreationService;
        }




        [SlashCommand("createnewcharacter", description: "Creates a New Character", ignoreGroupNames: false, runMode: RunMode.Async)]
        public async Task JoinBotAsync()
        {
           
         //   string msg = _characterCreationService.CreateCharacter(Context.User.Id);
                var mb = new ModalBuilder()
                .WithTitle("Create Your Character")
                .WithCustomId("New Character")
                .AddTextInput("Race?", "Race_name", placeholder: "Elf")
                .AddTextInput("Bio?", "Your_description", TextInputStyle.Paragraph,
                "rusic high elf with dark blue eyes and long green hair");
            try
            {
                await Context.Interaction.RespondWithModalAsync(mb.Build());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

          
        }


    }
}
