using Discord;

namespace SlapBott.Handlers
{
    internal class Responder(IDiscordInteraction a)
    {
        public Task RespondAsync = a.RespondAsync;

    }

}