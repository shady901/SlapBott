using MediatR;
using SlapBott.Requests;
using SlapBott.Services.Dtos;
using SlapBott.Services.Implmentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.RequestHandlers
{
    public class GetRaidCharacterHandler(IMediator mediator, EnemyService enemyService) : IRequestHandler<RequestGetRaidCharacter, RaidBossDto>
    {
        private IMediator _mediator = mediator;
        private EnemyService _enemyService = enemyService;

        public Task<RaidBossDto> Handle(RequestGetRaidCharacter request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_enemyService.GetEnemyTargetByID<RaidBossDto>(request.EnemyId));
        }
    }
}
