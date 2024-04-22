using Discord;

namespace SlapBott.Handlers
{
    internal class RespondHandler(IDiscordInteraction interaction)
    {
        public IDiscordInteraction Interaction { get; } = interaction;


        

    }
}