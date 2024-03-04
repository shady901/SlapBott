﻿using SlapBott.Services.Combat.Models;
using SlapBott.Services.Contracts;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using SlapBott.Data.Repos;

namespace SlapBott.Services.Implmentations
{
    public class CombatStateService
    {
        private CombatStateRepositry? _stateRepo;

        public CombatStateService(CombatStateRepositry combatStateRepositry)
        {
            _stateRepo = combatStateRepositry;


        }

        public void SaveState(CombatStateDto state)
        {
            _stateRepo.SaveCombatState(state.ToCombatState());
        }


        public CombatStateDto GetCombatStateByID(int stateID)
        {
            return new CombatStateDto().FromCombatState(_stateRepo.GetCombatStateByID(stateID));
        }
        public CombatStateDto GetCombatStateByChannelID(ulong channel)
        {
            return new CombatStateDto().FromCombatState(_stateRepo.GetCombatStateByChannelID(channel));
        }
        public bool CheckIfCombatStateExists(int stateID)
        {

            var state = GetCombatStateByID(stateID);

            if (state == null)
            {
                return false;
            }

            return true;
        }

    }
}