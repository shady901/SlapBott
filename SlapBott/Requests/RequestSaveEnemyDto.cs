using Discord.Net;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SlapBott.Requests
{
    public class RequestSaveEnemyDto(EnemyDto enemyDto) : IRequest<EnemyDto> 
    {
        public EnemyDto EnemyDto { get; } = enemyDto;
    }
}
