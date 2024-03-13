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
            try
            {
                await Context.Interaction.RespondAsync(embed:GetChoseRaceEmbed(),components:GetChoseRaceMessageComponent());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public Embed GetChoseRaceEmbed()
        {
            Embed embed = new EmbedBuilder()
             .WithTitle("Chose Your Race")
             .WithDescription("Elf: Bonus to Dexterity(example)\n Human: Bonuses to Health and Armor")
             .Build();
            return embed;
        }
        public MessageComponent GetChoseRaceMessageComponent()
        {
            var em = new SelectMenuBuilder()
            .WithPlaceholder("Select An option")
            .WithCustomId("createcharacter_selectclass")
            .WithMinValues(1)
            .WithMaxValues(1)
            .AddOption("Elf", "elf", "Bonus Dex")
            .AddOption("Human", "human", "Bonus Health and Armor");

            var builder = new ComponentBuilder()
             .WithSelectMenu(em)
             .Build();

            return builder;
        }


    }
}
