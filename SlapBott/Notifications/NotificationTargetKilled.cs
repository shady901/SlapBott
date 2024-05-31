using MediatR;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Notifications
{
    public class NotificationTargetKilled(PlayerCharacterDto playerCharacterDto, EnemyDto enemyDto):INotification
    {
       public PlayerCharacterDto PlayerCharacterDto = playerCharacterDto;
        public EnemyDto EnemyDto = enemyDto;
    }
}
