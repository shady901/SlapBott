using SlapBott.Data.Enums;
using SlapBott.Data.Models;

using SlapBott.Services.Contracts;
using SlapBott.Services.Dtos;
namespace SlapBott.Services.Implmentations
{
    public class CombatManager
    {
        private CombatStateService _combatStateService;
        private CombatStateDto? _state = new();
        private EnemyService? _enemyService;
        public CombatManager(CombatStateService combatStateService, EnemyService enemyService)
        {  
            _combatStateService = combatStateService;
            _enemyService = enemyService;
        }
        public void SaveState()
        {
                _combatStateService.SaveState(_state);
        }
        public void GetStateById(int id)
        {
            if (id > 0) 
            {
                _state = _combatStateService.GetCombatStateByID(id);
            }
          
            
        }
        public void GetStateByChannelId(ulong id)
        {
            if (id > 0)
            {
                _state =_combatStateService.GetCombatStateByChannelID(id);
            }
        }
        public List<int> GetEnemyIDs()
        {
            return _state.EnemyIds.ToList();
        }
        public int GetEnemyIDByTarget(string target)
        {

            var d = _state.EnemyIds.ToList();
            return d[Convert.ToInt32(target)]; 
        }
        public EnemyDto GetEnemyById(int ID)
        {

            return _enemyService.GetEnemyByID(ID);
        }
        public void Turn(int StateID,int TargetId,SkillDto skillDto, PlayerCharacterDto? characterDto = null, EnemyDto? enemyDto = null)
        {
            GetStateById(StateID);
            //SelectTarget - Player or Enemy Object
            //GetSkillData
            //GetAttackerData
            //GetTargetData
            //Do Damage - calculate off both player data
            //ApplyEffects
            //SaveTarget
            //SaveTurn




           
            //end turn 
            // if its not a raid boss begin enemy turn 


            SaveState();
        }
        
        //public int CalculateDamageOfSkill(PlayerCharacterDto character, Skill skill ) 
        //{
           
        //    //apply buffs and debuffs of the player when we have set themup


        //    // attack base dmg + stat for skill * elemental damage %
        //    int damage = character.CalculateBaseStatDamageFor(skill) + character.GetCombinedStat(StatType.AttackDamage);
        //    damage = damage * character.GetCombinedStat(skill.GetSkillStatTypeByElement());

        //    return damage;
            
        //}
        public void ApplyDamage<T>(StatType elementalType, int damage, T target) where T : ITarget
        {
            target.ApplyDamage(damage, elementalType);
         
        }
        public StatType GetStatTypeByElementalType(ElementalType elementalType)
        {
            switch (elementalType)
            {
              
                case ElementalType.Fire:
                    return StatType.FireResistance;
                case ElementalType.Frost:
                    return StatType.FrostResistance;
                case ElementalType.Lightning:
                    return StatType.LightningResistance;
                case ElementalType.Physical:
                    return StatType.PhysicalResistance;
                case ElementalType.Chaos:
                    return StatType.ChaosResistance;
                default:
                    return StatType.none;
            }
        }


    }
}
