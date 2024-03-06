using SlapBott.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlapBott.Services.Combat.Models
{
    public class Turn
    {
        public int Id { get; set; }
        public int TurnId { get; set; }
        public int CombatStateId { get; set; }
        
        public List<TurnAttackRecord> AttackRecords { get; set; }



    }
    public class TurnAttackRecord()
    { 
        public int Id { get; set; }
        public int SkillId { get; set; }
        [ForeignKey("SkillId")]
        public virtual Skill Skill { get; set; }
        public Dictionary<int,int> TargetDmg { get; set; }

        public int AttackerId { get; set; }

        [ForeignKey("AttackerId")]
        public virtual Character Attacker { get; set; }
    }


    public class DamageTarget
    {
        public int Id { get; set; }
        public int Damage { get; set; }

        public int TargetId { get; set; }

        [ForeignKey("TargetId")]
        public virtual Character Target { get; set; }
    }

}