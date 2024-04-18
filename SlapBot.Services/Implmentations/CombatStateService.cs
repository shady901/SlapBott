using SlapBott.Services.Dtos;
using SlapBott.Data.Repos;
using SlapBott.Services.Combat.Models;
using SlapBott.Data.Models;

namespace SlapBott.Services.Implmentations
{
    public class CombatStateService
    {
        private CombatStateRepositry? _stateRepo;
        private EnemyStateRepo? _enemyStateRepo;
        private PlayerStateRepo? _playerStateRepo;
        public CombatStateService(CombatStateRepositry combatStateRepositry,EnemyStateRepo enemyStateRepo,PlayerStateRepo playerStateRepo)
        {
            _enemyStateRepo=enemyStateRepo;
            _playerStateRepo=playerStateRepo;
            _stateRepo = combatStateRepositry;


        }

        public CombatState SaveState(CombatStateDto stateDto)
        {
            CombatState state = _stateRepo.GetByIdOrNew(stateDto.Id);
           return _stateRepo.SaveCombatState(stateDto.ToCombatState(state));
        }

      
        public CombatStateDto GetCombatStateByIdOrNew(int stateID)
        {
            return new CombatStateDto().FromCombatState(_stateRepo.GetByIdOrNew(stateID));
        }

        public CombatStateDto AssignEnemyToState(CombatStateDto state,IEnumerable<int> enemyIds)
        {

            state = new() { Enemies = CreateNewEnemyCombatStateList(enemyIds) };
            return state;
        }
       
        public EnemyCombatState SaveEnemyCombatState(EnemyCombatStateDto stateDto) 
        {
            EnemyCombatState state = _enemyStateRepo.GetByIdOrNew(stateDto.Id);
            return _enemyStateRepo.SaveState(stateDto.ToEnemyState(state));

        }
        public PlayerCharacterCombatState SavePlayerCombatState(PlayerCharacterCombatStateDto stateDto)
        {
            PlayerCharacterCombatState state = _playerStateRepo.GetByIdOrNew(stateDto.Id);
            return _playerStateRepo.SaveState(stateDto.ToCharactersState(state));

        }
        private List<EnemyCombatStateDto> CreateNewEnemyCombatStateList(IEnumerable<int> enemyIds)
        {
            List<EnemyCombatStateDto> myEnemys = new List<EnemyCombatStateDto>();
            foreach (int enemyId in enemyIds)
            {
                myEnemys.Add(new EnemyCombatStateDto() { ParticipantId = enemyId });
            }
            return myEnemys;
        }

        public EnemyCombatStateDto GetEnemyStateByIdOrNew(int stateID)
        {
            return new EnemyCombatStateDto().FromEnemyState(_enemyStateRepo.GetByIdOrNew(stateID));
        }
    }
}
