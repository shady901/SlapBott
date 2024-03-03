using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Combat.Models
{
    public class CombatState
    {

        public int Id { get; set; }
        public ulong ChannelID { get; set; }
        public bool IsPlayerTurn { get; set; }
        public IEnumerable<int> CharcterIds { get; set; }
        public IEnumerable<int> EnemyIds { get; set; }
        
        public CombatState() 
        {
            CharcterIds = new List<int>();
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
