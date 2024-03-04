﻿using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Services.Combat.Models;
using SlapBott.Services.Contracts;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Implmentations
{
    public class CombatManager
    {
        private CombatStateService _combatStateService;
        private CombatStateDto? _state = new();
        private CharacterService? _characterService;
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
            if (id <= 0) 
            {
                _state = _combatStateService.GetCombatStateByID(id);
            }
          
            
        }
        public void GetStateByChannelId(ulong id)
        {
            if (id <= 0)
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
        public void PlayerTurn(CharacterDto character, Skill skill, string Target)
        {
            // buffs and afflictions not implemented in turns  //apply any retaliation(thorns, or debufs) to player

            //EnemyDto myTarget = _enemyService.GetEnemyByID(GetEnemyIDByTarget(Target));


            ApplyDamage(GetStatTypeByElementalType(skill.ElementalType),CalculateDamageOfSkill(character, skill), myTarget);
           
            
           
           // _enemyService.SaveEnemy(myTarget);
            //end turn 
            // if its not a raid boss begin enemy turn 



        }
        public void EnemyTurn(CharacterDto character, Skill skill, string Target)
        {
            
           

           

           //end turn 
            // if its not a raid boss begin enemy turn 



        }
        public int CalculateDamageOfSkill(CharacterDto character, Skill skill ) 
        {
           
            //apply buffs and debuffs of the player when we have set themup


            // attack base dmg + stat for skill * elemental damage %
            int damage = character.CalculateBaseStatDamageFor(skill) + character.GetCombinedStat(StatType.AttackDamage);
            damage = damage * character.GetCombinedStat(skill.GetSkillStatTypeByElement());

            return damage;
            
        }
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
