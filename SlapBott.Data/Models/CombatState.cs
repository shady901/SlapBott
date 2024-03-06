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
        public bool HadTurn;
        public bool IsActive;

        [ForeignKey("CharacterId")]
        public virtual Character Character { get; set; }

        [ForeignKey("CombatStateId")]
        public virtual CombatState CombatState { get; set; }

    }
    public class CombatStateEnemies
    { 
    
    
    }
    public class CombatState
    {

        public int Id { get; set; }
        public ulong ChannelID { get; set; }
        public bool IsPlayerTurn { get; set; }




        public int CurrentTurnId { get; set; }

        [ForeignKey("CurrentTurnId,Id")] 
        public IEnumerable<Turn> Turns { get; set; }




        public IEnumerable<CombatStateCharacter> Charcters { get; set; }
        public IEnumerable<CombatStateEnemies> Enemies { get; set; }
        
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
