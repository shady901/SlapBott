using SlapBott.Data.Models;
using SlapBott.Services.Combat.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlapBott.Services.Dtos
{
    public class CombatStateDto
    {

        public int Id { get; set; }
        public ulong ChannelID { get; set; }

        public int CurrentTurnId { get; set; }

        //Individual Player Turns 
        public ICollection<TurnDto> Turns { get; set; }


        public ICollection<PlayerCharacterCombatStateDto> Characters { get; set; } // this will have active and non active Characters in it


        public ICollection<EnemyCombatStateDto> Enemies { get; set; } //this will have 1 or n number of enemy characters        

        public CombatStateDto()
        {
            Turns = new List<TurnDto>();
            Characters = new List<PlayerCharacterCombatStateDto>();
            Enemies = new List<EnemyCombatStateDto>();
        }
       

    

        public CombatStateDto FromCombatState(CombatState state)
        {
            
            Id = state.Id;
            CurrentTurnId = state.CurrentTurnId;           
            DtoHelper.ConvertCollection(state.Turns?? new List<Turn>(), this.Turns, "FromTurn");
            DtoHelper.ConvertCollection(state.Characters?? new List<PlayerCharacterCombatState>(), this.Characters, "FromCharactersState");
            DtoHelper.ConvertCollection(state.Enemies?? new List<EnemyCombatState>(), this.Enemies, "FromEnemyState");
            return this;


            


            
        }



        //will convert dto to state, and will convert enemy states when it has been setup  which will be when turns are 0
        public CombatState ToCombatState(CombatState? combatState = null)
        {
            if (CurrentTurnId > 0)
            {   
                DtoHelper.ConvertCollection(this.Turns, combatState.Enemies, "ToEnemyState");
                
            }
            DtoHelper.ConvertCollection(this.Characters ?? new List<PlayerCharacterCombatStateDto>(),combatState.Characters, "FromCharactersState");
            DtoHelper.ConvertCollection(this.Enemies ?? new List<EnemyCombatStateDto>(), combatState.Enemies, "FromEnemyState");
            combatState.CurrentTurnId = CurrentTurnId;           
            return combatState;
        }
       
    }
}
