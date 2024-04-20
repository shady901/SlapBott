
using MediatR;
using SlapBott.Requests;
using SlapBott.Services.Dtos;
using SlapBott.Services.Implmentations;

namespace SlapBott.RequestHandlers
{
    internal class CreatePlayerCharacterHandler(PlayerCharacterService playerCharacterService ) : IRequestHandler<CreatePlayerCharacter, PlayerCharacterDto>
    {
        private readonly PlayerCharacterService playerCharacterService = playerCharacterService;

        public Task<PlayerCharacterDto> Handle(CreatePlayerCharacter request, CancellationToken cancellationToken)
        {
            var userId = request.UserId;
            var registrationId = request.RegistrationId;
                

            var _playerCharacter = playerCharacterService.GetTempPlayerCharacterByDiscordIdOrNew(userId, registrationId);
            return Task.FromResult(PlayerCharacterDto.FromCharacter(_playerCharacter));
        }
    }
}
