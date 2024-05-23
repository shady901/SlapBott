using Discord;
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
    public class RequestGetRaidCharacter : IRequest<RaidBossDto>
    {
        public int EnemyId { get; }

        public RequestGetRaidCharacter(int enemyId)
        {
            EnemyId = enemyId;
        }
    }
}
