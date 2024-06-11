
using SlapBott.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace SlapBott.Data.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ulong CharExp { get; set; }
        public int level => (int)(450 + Math.Sqrt(202500 + 1800 * CharExp)) / 900;
        //public List<Ailments> ailments { get; set; }
        //public List<Buff> Buffs { get; set; }
        //public int BStatsId { get; set; }
        //[ForeignKey("BStatsId")]
        //public  Stats? BStats { get; set; }
        public int StatsId { get; set; }
        [ForeignKey("StatsId")]
        public virtual Stats? Stats { get; set; }
        public int InventoryId { get; set; }
       // [ForeignKey("InventoryId")]
        public Inventory? Inventory { get; set; }

        public int CombatStateID { get; set; }
        public int? RaceId { get; set; }
        [ForeignKey("RaceId")]
        public virtual Race? Race { get; set; }
        public int? ClassId { get; set; }
        [ForeignKey("ClassId")]
        public virtual CharacterClass? CharacterClass { get; set; }

        public virtual List<int>? LearnedSkillIds { get; set; }

        public ICollection<LootTable> LootTable { get; set; }



        // public virtual CharacterClass CharacterClass { get; set; }
        //public virtual SubClass SubClass { get; set; }
        // public Classes SelectedCharacterClass { get; set; }
        // public Races SelectedRace { get; set; }

        public Character()
        {
            




        }
      
        
    }
}







