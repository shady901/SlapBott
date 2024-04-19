using Microsoft.Extensions.Logging.Abstractions;
using SlapBott.Data.Models;
using SlapBott.Services.Combat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
   
    public class ParticipantCombatStateDto
    {
        public int Id { get; set; }
        public int CombatStateId { get; set; }
        public int ParticipantId { get; set; }
        public bool HadTurn { get; set; }
        public bool IsActive { get; set; }
       
        public virtual CombatState CombatState { get; set; }

      
    }

    public class PlayerCharacterCombatStateDto : ParticipantCombatStateDto
    {

        public virtual PlayerCharacterDto Character { get; set; }

        public PlayerCharacterCombatStateDto FromCharactersState(PlayerCharacterCombatState PlayerState)
        {
            return new PlayerCharacterCombatStateDto(){
                Id = PlayerState.Id,
                CombatState = PlayerState.CombatState,
                CombatStateId = PlayerState.CombatStateId,
                ParticipantId = PlayerState.ParticipantId,
                HadTurn = PlayerState.HadTurn,
                IsActive = PlayerState.IsActive,
               
            };
        }
        public PlayerCharacterCombatState ToCharactersState(PlayerCharacterCombatState? PlayerState = null)
        {

            PlayerState.CombatState = CombatState;
            PlayerState.CombatStateId = CombatStateId;
            PlayerState.ParticipantId = ParticipantId;
            PlayerState.HadTurn = HadTurn;
            PlayerState.IsActive = IsActive;
           
            return PlayerState;
        }
    }

    public class EnemyCombatStateDto : ParticipantCombatStateDto
    {
        public virtual EnemyDto Enemy { get; set; }
        public EnemyCombatStateDto FromEnemyState(EnemyCombatState EnemyState)
        {
            return new EnemyCombatStateDto()
            {
                Id = EnemyState.Id,
                CombatState = EnemyState.CombatState,
                CombatStateId = EnemyState.CombatStateId,
                ParticipantId = EnemyState.ParticipantId,
                HadTurn = EnemyState.HadTurn,
                IsActive = EnemyState.IsActive,               
            };
        }
        public EnemyCombatState ToEnemyState(EnemyCombatState? EnemyState = null)
        {

            
            EnemyState.CombatStateId = CombatStateId;
            EnemyState.ParticipantId = ParticipantId;
            EnemyState.HadTurn = HadTurn;
            EnemyState.IsActive = IsActive;           
            return EnemyState;
        }

    }

}

