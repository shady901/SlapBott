using MediatR;
using SlapBott.Data.Contracts;
using SlapBott.Requests;
using SlapBott.Services.Dtos;
using SlapBott.Services.Implmentations;

namespace SlapBott.RequestHandlers
{
    public class GetEnemyCharacterHandler: IRequestHandler<RequestGetEnemyCharacter, RaidBossDto> 
    {
        private readonly IMediator _mediator;
        private readonly EnemyService _enemyService;

        public GetEnemyCharacterHandler(EnemyService enemyService, IMediator mediator)
        {
            _enemyService = enemyService;
            _mediator = mediator;
        }

        public async Task<RaidBossDto> Handle(RequestGetEnemyCharacter request, CancellationToken cancellationToken)
        {
           return await Task.FromResult(_enemyService.GetEnemyTargetByID<RaidBossDto>(request.EnemyId));
        }
    }
}
