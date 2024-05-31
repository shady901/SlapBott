using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Objects
{
    public class AttackResults<TSender,TReceiver>(TSender sender, TReceiver receiver) where TReceiver : Target where TSender : Target
    {
       public int Damage { get; set; } = 0;
        public bool Dodged { get; set; } = false;
        public SkillDto? Skill { get; set; }
        public bool Crit { get; set; } = false;
        public bool TargetKilled { get; set; } = false;
        public TSender? Sender { get; set; } = sender;
        public TReceiver? Receiver { get; set; } = receiver;
    }
}
