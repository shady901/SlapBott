using SlapBott.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlapBott.Services.Combat.Models
{


    /*
     * 
     * Turn is for an Individual Character
     * 
     * 
     */
    public class Turn
    {
        public int Id { get; set; }

        public int TurnId { get; set; }
        public int CombatStateId { get; set; }


        public int AttackerId { get; set; }



        public List<TurnAttackRecord> AttackRecords { get; set; } // is the attacks for 


        [ForeignKey("AttackerId")]
        public virtual Character Attacker { get; set; }

        [ForeignKey("TurnId,CombatStateId")]
        public virtual CombatState CombatState { get; set; }


    }





}