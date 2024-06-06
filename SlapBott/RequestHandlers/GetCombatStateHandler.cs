using MediatR;
using MediatR.Pipeline;
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
    public class GetCombatStateHandler(CombatStateService combatStateService) : IRequestHandler<RequestCombatStateDto, CombatStateDto>
    {
        private CombatStateService combatStateService = combatStateService;

        public Task<CombatStateDto> Handle(RequestCombatStateDto request, CancellationToken cancellationToken)
        {
           return Task.FromResult(combatStateService.GetCombatStateByIdOrNew(request.Id));
        }

       
    }
}
