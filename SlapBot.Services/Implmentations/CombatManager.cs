﻿using SlapBott.Data.Models;
using SlapBott.Services.Combat.Models;
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
        public void PlayerTurn(CharacterDto character, Skill skill, int Target)
        {
            //get skill stats, scaling and stattype
            //get those stats from character and items
            //calc skill off char, modify based on effects
            //apply skill to target
            //apply buffs to player
            //apply afflictions and debufs to target
            //apply any retaliation(thorns, or debufs) to player
            //end turn 
            // if its not a raid boss begin enemy turn 



        }





    }
}
