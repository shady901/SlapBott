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

    public class CombatStateCharacter
    {

        public int Id;
        public int CombatStateId;
        public int CharacterId;


        [ForeignKey("CharacterId")]
        public virtual Character Character;

        [ForeignKey("CombatStateId")]
        public virtual CombatState CombatState;


    }
    public class CombatState
    {

        public int Id { get; set; }
        public ulong ChannelID { get; set; }
        public bool IsPlayerTurn { get; set; }

        public int CurrentTurnId { get; set; }


        [ForeignKey("CurrentTurnId")]
        public virtual Turn CurrentTurn { get; set; }


        public IEnumerable<Turn> Turns { get; set; }
        public IEnumerable<CombatStateCharacter> Charcters { get; set; }
        public IEnumerable<int> EnemyIds { get; set; }
        
        public CombatState() 
        {
            CharcterIds = new List<CombatStateCharacter>();
            EnemyIds = new List<int>();
        }
        public CombatState(IEnumerable<int> playerCharacters, IEnumerable<int> enemyCharacters) 
        {
            CharcterIds = playerCharacters;
            EnemyIds = enemyCharacters;
        }
        //public List<Effects> effects { get; set; }


    }
}
