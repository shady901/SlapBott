
using SlapBott.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace SlapBott.Data.Models
{
    public  class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ulong CharExp { get; set; }
        public int level => (int)(450 + Math.Sqrt(202500 + 1800 * CharExp)) / 900;
        //public List<Ailments> ailments { get; set; }
        //public List<Buff> Buffs { get; set; }
        public  Stats? BStats { get; set; }
        public int StatsId { get; set; }
        public Stats Stats;
        public int InventoryId { get; set; }
        public Inventory Inventory;
       // public virtual Race? Race { get; set; }
       // public virtual CharacterClass CharacterClass { get; set; }
       //public virtual SubClass SubClass { get; set; }
       // public Classes SelectedCharacterClass { get; set; }
       // public Races SelectedRace { get; set; }

        public Character()
        {
            




        }
      
        
    }
}







