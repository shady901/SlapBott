using SlapBott.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Combat.Models
{


    public class ParticipantCombatState
    {
        public int Id { get; set; }
        public int CombatStateId { get; set; }
        public int ParticipantId { get; set; }
        public bool HadTurn { get; set; }
        public bool IsActive { get; set; }


        [ForeignKey("CombatStateId")]
        public virtual CombatState CombatState { get; set; }


    }

    public class PlayerCharacterCombatState: ParticipantCombatState
    {


        [ForeignKey("ParticipantId")]
        public virtual PlayerCharacter Character { get; set; }
        
       
    }

    public class EnemyCombatState: ParticipantCombatState
    {

        [ForeignKey("ParticipantId")]
        public virtual Enemy Enemy { get; set; }


    }


    public class CombatState
    {

        public int Id { get; set; }
        public ulong ChannelID { get; set; }

        public int CurrentTurnId { get; set; }

        //Individual Player Turns 
        
        public ICollection<Turn> Turns { get; set; }

        [ForeignKey("Id")]
        public ICollection<PlayerCharacterCombatState> Characters { get; set; } // this will have active and non active Characters in it

        [ForeignKey("Id")]
        public ICollection<EnemyCombatState> Enemies { get; set;} //this will have 1 or n number of enemy characters        
        public CombatState()
        {

        }


    }
}
