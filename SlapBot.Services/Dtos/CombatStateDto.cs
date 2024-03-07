using SlapBott.Services.Combat.Models;

namespace SlapBott.Services.Dtos
{
    public class CombatStateDto
    {

        public int Id { get; set; }
        public ulong ChannelID { get; set; }      
        public bool IsPlayerTurn { get; set; }
        public IEnumerable<CharacterDto> CharcterIds { get; set; }
        public IEnumerable<int> EnemyIds { get; set; }
        //public List<CharacterDto> Frontline => CharcterIds.Where(x => x.IsMelee).ToList();
        //public List<CharacterDto> Backline => CharcterIds.Where(x => x.IsRanged).ToList();

        public CombatStateDto()
        {
            //CharcterIds = new List<int>();
            //EnemyIds = new List<int>();
        }
        public CombatStateDto(IEnumerable<int> playerCharacters, IEnumerable<int> enemyCharacters)
        {
            //CharcterIds = playerCharacters;
            //EnemyIds = enemyCharacters;
        }



        public CombatStateDto FromCombatState(CombatState state)
        {
            return new CombatStateDto
            {
                Id = state.Id,
                //IsPlayerTurn = state.IsPlayerTurn,
               // CharcterIds = state.Charcters.Select(x => {
               // return (new CharacterDto().FromCharacter(x.Character));
               //})
              
               //EnemyIds = state.EnemyIds
            };
        }
        public CombatState ToCombatState(CombatState? combatState = null)
        {

            combatState.Id = Id;
            //combatState.IsPlayerTurn = IsPlayerTurn;
            return combatState;
        }
        //public List<Effects> effects { get; set; }
    }
}
