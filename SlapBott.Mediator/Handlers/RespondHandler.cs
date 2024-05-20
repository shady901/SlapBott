using Discord;

namespace SlapBott.Handlers
{
    public class RespondHandler(IDiscordInteraction interaction)
    {
        public IDiscordInteraction Interaction { get; } = interaction;


        

    }
}