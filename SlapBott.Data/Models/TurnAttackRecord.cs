
using SlapBott.Services.Combat.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlapBott.Data.Models
{
    public class TurnAttackRecord()
    {
        public int Id { get; set; }
        public int SkillId { get; set; }

        public int TurnId { get; set; }

        [ForeignKey("TurnId")] 
        public virtual Turn Turn { get; set; }

        [ForeignKey("SkillId")]
        public virtual Skill Skill { get; set; }
        
        ///public Dictionary<int, int> TargetDmg { get; set; }

    }
}
