using Discord.Net;
using MediatR;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Requests
{
    public class RequestGetSkill(int SkillId) : IRequest<SkillDto>
    {
        public int SkillId = SkillId;
    }
}
