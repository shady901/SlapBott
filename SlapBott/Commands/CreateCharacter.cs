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
        private InteractionHandler? _handler;
        public InteractionService Commands { get; set; }
        public CreateCharacter(InteractionHandler? handler) 
        {
            _handler = handler;
               // _characterCreationService = characterCreationService;
        }




        [SlashCommand("createnewcharacter", description: "Creates a New Character", ignoreGroupNames: false, runMode: RunMode.Async)]
        public async Task JoinBotAsync()
        {

            var em = new SelectMenuBuilder()
           .WithPlaceholder("Select An option")
           .WithCustomId("SelectClass")
           .WithMinValues(1)
           .WithMaxValues(1)
           .AddOption("Elf", "elf", "Bonus Dex")
           .AddOption("Human", "human", "Bonus Health and Armor");

            Embed embed = new EmbedBuilder()
                 .WithTitle("Chose Your Race")
                 .WithDescription("Elf: Bonus to Dexterity(example)\n Human: Bonuses to Health and Armor")
                .Build();
            //ButtonBuilder testbutton = new ButtonBuilder()
            //    .WithCustomId("testbutton")
            //    .WithLabel("Attack")
            //    .WithStyle(ButtonStyle.Primary);
          
            var builder = new ComponentBuilder()         
             .WithSelectMenu(em);
            

            try
            {
                await Context.Interaction.RespondAsync(embed:embed,components:builder.Build());
             
              

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

          
        }


    }
}
