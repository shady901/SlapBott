using Discord;
using MediatR;
using SlapBott.Services.Dtos;

namespace SlapBott.Requests
{
    public class RespondWithPlayerCharacter(
        PlayerCharacterDto playercharacter,
        Func<string, Embed[], bool, bool, AllowedMentions, MessageComponent, Embed, RequestOptions> respondAsync)
        : IRequest<bool>
    {
        public PlayerCharacterDto Playercharacter { get; } = playercharacter;
        public Func<string, Embed[], bool, bool, AllowedMentions, MessageComponent, Embed, RequestOptions> RespondAsync { get; } = respondAsync;
    }
}