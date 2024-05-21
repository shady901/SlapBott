
using MediatR;
using SlapBott.Data.Enums;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Notifactions
{
    public class SendRaidBossRequest(RaidBossDto bossDto,Regions region) : IRequest<bool>
    {
        public RaidBossDto Component = bossDto;
        public Regions Region = region;
    }
}
