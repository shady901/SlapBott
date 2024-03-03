using SlapBott.Data.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
    public class CharacterDto
    {
        public required CombatStats Stats { get; set; }
        public List<Skill> Skills { get; set; }

       public CharacterDto FromCharacter(Character character)
        {
            return new CharacterDto { Stats =character.CombatStats }; 
        }

        
        public Skill GetBySkill(string skill)
        {
            if (skill == string.Empty)
            {
                return null;
            }
            var temp = Skills.FirstOrDefault(x => x.Name.ToLower().Contains(skill.ToLower()));
          
            return temp;
            
        
        }
    }
    
}
