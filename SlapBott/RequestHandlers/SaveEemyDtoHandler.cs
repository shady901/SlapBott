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
    public class SaveEemyDtoHandler(IMediator mediator, EnemyService enemyService):IRequestHandler<RequestSaveEnemyDto,EnemyDto>
    {
        private IMediator _mediator = mediator;
        private EnemyService _enemyService = enemyService;

        public Task<EnemyDto> Handle(RequestSaveEnemyDto request, CancellationToken cancellationToken)
        {
           return Task.FromResult(_enemyService.SaveEnemy(request.EnemyDto));
        }
    }
}
