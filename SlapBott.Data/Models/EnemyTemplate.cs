
using System.ComponentModel.DataAnnotations.Schema;


namespace SlapBott.Data.Models
{
    public class EnemyTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        
        public Stats? Stats { get; set; }
               
        public int? RaceId { get; set; }
        [ForeignKey("RaceId")]
        public virtual Race? Race { get; set; }
        public int? ClassId { get; set; }
        [ForeignKey("ClassId")]
        public virtual CharacterClass? CharacterClass { get; set; }



        public virtual List<int>? LearnedSkillIds { get; set; }


    }
}
