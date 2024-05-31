using MediatR;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Notifications
{
    public class NotificationPlayerCharacterDied(PlayerCharacterDto playerCharacterDto) : INotification
    {
        public PlayerCharacterDto playerCharacter = playerCharacterDto;
    }
}
