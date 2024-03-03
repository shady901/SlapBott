using SlapBott.Data.Models;
using SlapBott.Services.Combat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
    public class CombatStateDto
    {

        public int Id { get; set; }
           public ulong ChannelID { get; set; }
      
        public bool IsPlayerTurn { get; set; }
        public IEnumerable<int> CharcterIds { get; set; }
        public IEnumerable<int> EnemyIds { get; set; }

        public CombatStateDto()
        {
            CharcterIds = new List<int>();
            EnemyIds = new List<int>();
        }
        public CombatStateDto(IEnumerable<int> playerCharacters, IEnumerable<int> enemyCharacters)
        {
            CharcterIds = playerCharacters;
            EnemyIds = enemyCharacters;
        }



        public CombatStateDto FromCombatState(CombatState state)
        {
            return new CombatStateDto 
            {
               Id = state.Id,
               IsPlayerTurn = state.IsPlayerTurn,
               CharcterIds = state.CharcterIds,
               EnemyIds = state.EnemyIds
            };
        }
        public CombatState ToCombatState(CombatState? combatState = null)
        {

            combatState.Id = Id;
            combatState.IsPlayerTurn = IsPlayerTurn;
            combatState.CharcterIds = CharcterIds;
            combatState.EnemyIds = EnemyIds;
            return combatState;
        }
        //public List<Effects> effects { get; set; }
    }
}
