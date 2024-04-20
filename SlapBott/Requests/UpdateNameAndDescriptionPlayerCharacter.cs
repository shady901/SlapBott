using Discord.WebSocket;
using MediatR;
using SlapBott.Services.Dtos;

namespace SlapBott.Requests
{
    internal class UpdateNameAndDescriptionPlayerCharacter(PlayerCharacterDto? playerCharacter, IReadOnlyCollection<SocketMessageComponentData> components) 
        : IRequest<PlayerCharacterDto?>
    {
        public PlayerCharacterDto? PlayerCharacter = playerCharacter;
        public IReadOnlyCollection<SocketMessageComponentData> Components = components;
    }
}
