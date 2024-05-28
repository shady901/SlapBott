using MediatR;
using SlapBott.Requests;
using SlapBott.Services.Dtos;
using SlapBott.Services.Implmentations;

namespace SlapBott.RequestHandlers
{
    public class GetExistingActiveCharacterOrNewHandler(PlayerCharacterService playerCharacterService, IMediator mediator) 
        : IRequestHandler<RequestGetExistingCharacterOrNew, PlayerCharacterDto>
    {
        private readonly PlayerCharacterService playerCharacterService = playerCharacterService;
        private readonly IMediator _mediator = mediator;

        public async Task<PlayerCharacterDto> Handle(RequestGetExistingCharacterOrNew request, CancellationToken cancellationToken)
        {
            bool temp = request.TempUser ?? false;
            var userId = request.UserId;

            var registration = await _mediator.Send(new GetRegistration(userId));
            if (!temp) { return PlayerCharacterDto.FromCharacter(await playerCharacterService.GetPlayerCharacterByCharacterId((int)registration.ActiveCharacterId)); }
            var _playerCharacter = await playerCharacterService.GetTempPlayerCharacterByDiscordIdOrNew(userId, (int)registration.Id);
            return PlayerCharacterDto.FromCharacter(_playerCharacter);
        }
    }
}
