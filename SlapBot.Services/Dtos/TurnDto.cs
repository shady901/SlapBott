using SlapBott.Data.Models;
using SlapBott.Services.Combat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
    public class TurnDto
    {
        public int Id { get; set; }

        public int TurnId { get; set; }
        public int CombatStateId { get; set; }


        public int AttackerId { get; set; }



        public List<TurnAttackRecord> AttackRecords { get; set; } // is the attacks for 


       
        public virtual Character Attacker { get; set; }
       
        public virtual CombatState CombatState { get; set; }



        public TurnDto FromTurn(Turn turn)
        {
            return new TurnDto
            {
              Id = turn.Id,
              TurnId = turn.TurnId,
              CombatStateId = turn.CombatStateId,
              AttackerId = turn.AttackerId,
              AttackRecords = turn.AttackRecords,
              Attacker = turn.Attacker,
              CombatState = turn.CombatState,
            };
        
        }
        public Turn ToTurn(Turn? turn = null)
        { 
            turn.Id = Id;
            turn.TurnId = turn.TurnId;
            turn.CombatState = CombatState;
            turn.Attacker = Attacker;
            turn.AttackRecords = AttackRecords;
            turn.AttackerId = AttackerId;
            turn.CombatState = CombatState;

            return turn;
        }
    }
}
