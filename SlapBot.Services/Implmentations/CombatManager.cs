using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Services.Combat.Models;
using SlapBott.Services.Contracts;
using SlapBott.Services.Dtos;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Formats.Tar;
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
        public void SetStateById(int id)
        {
            if (id > 0) 
            {
                _state = _combatStateService.GetCombatStateByID(id);
            }
          
            
        }
        public CombatStateDto GetStateById(int id)
        {
           
            if (id > 0)
            {
                return _combatStateService.GetCombatStateByID(id);
            }
            return null;

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
            List<int> enemyIds = new List<int>();
            foreach (var enemy in _state.Enemies)
            {
               enemyIds.Add(enemy.Id);
            }
            return enemyIds;
        }
        public int GetEnemyIDByTarget(string target)
        {

            
            return GetEnemyIDs()[Convert.ToInt32(target)]; 
        }
        //public EnemyDto GetEnemyById(int ID)
        //{

        //    return _enemyService.GetEnemyByID(ID);
        //}

        // attackers turn
        public void Turn<T>(int StateID, int TargetId, SkillDto skillDto, T? characterDto = null, T? enemyDto = null) where T : Target
        {
            GetStateById(StateID); // state for something not sure at this time

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
        public void CreateNewCombatState(IEnumerable<int> enemyIds) 
        {

            _state = new() { Enemies = CreateNewEnemyCombatStateList(enemyIds) }; 
            _combatStateService.SaveState(_state);
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
    }
}
