using MediatR;
using SlapBott.Data.Models;
using SlapBott.Services.Dtos;

namespace SlapBott.Requests
{
    public class RequestSavePlayerCharacterDto(PlayerCharacterDto playerCharacterDto) : IRequest<bool>
    {
        public PlayerCharacterDto CharacterDto { get; } = playerCharacterDto;

    }
}