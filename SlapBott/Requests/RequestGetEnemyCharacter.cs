using Discord.Net;
using MediatR;
using SlapBott.Services.Dtos;
using SlapBott.Services.Implmentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Requests
{
    public class RequestGetEnemyCharacter : IRequest<RaidBossDto>
    {
        public int EnemyId { get; }

        public RequestGetEnemyCharacter(int enemyId)
        {
            EnemyId = enemyId;
        }
    }
}
