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
    public class GetEnemyCombatStateHandler(CombatStateService combatStateService) : IRequestHandler<RequestGetEnemyCombatState, EnemyCombatStateDto>
    {
       private CombatStateService _combatStateService = combatStateService;
        public Task<EnemyCombatStateDto> Handle(RequestGetEnemyCombatState request, CancellationToken cancellationToken)
        {
          return Task.FromResult( _combatStateService.GetEnemyStateByIdOrNew(request.StateId));

        }
    }
}
