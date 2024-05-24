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
    public class GetSkillHandler(SkillService skillService) : IRequestHandler<RequestGetSkill, SkillDto>
    {
        private SkillService _skillService = skillService;

        public Task<SkillDto> Handle(RequestGetSkill request, CancellationToken cancellationToken)
        {
         return Task.FromResult(new SkillDto().FromSkill(_skillService.GetSkillById(request.SkillId)));
        }
    }
}
