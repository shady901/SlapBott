using Discord;
using Discord.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SlapBott.Services.Objects;
using SlapBott.Services.Dtos;

namespace SlapBott.Requests
{
    public class RequestAttackBack(PlayerCharacterDto playerCharacterDto, EnemyDto enemyDto) : IRequest<AttackResults<EnemyDto,PlayerCharacterDto>>
    {
       public PlayerCharacterDto PlayerCharacterDto = playerCharacterDto;
       public EnemyDto EnemyDto = enemyDto;
    }
}
