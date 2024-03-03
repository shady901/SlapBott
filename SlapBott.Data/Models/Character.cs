
using SlapBott.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace SlapBott.Data.Models
{
    public class Character
    {
        [ForeignKey("DiscordID")]
        public virtual Registration Registration { get; set; }
        public bool HasLeveled { get; set; } =false;
        public int Id { get; set; }
        public int DiscordID { get; set; }
      //public Stats Stats { get; set; }

        public ulong CharExp { get; set; }
        public int level => (int)(450 + Math.Sqrt(202500 + 1800 * CharExp)) / 900;
     //   public List<Ailments> ailments { get; set; }
     //   public List<Buff> Buffs { get; set; }
        public CombatStats CombatStats;
        public SubClass CharacterClass { get; set; }
        public ICollection<Equipment> Equiped { get; set; }
        
        public Character()
        {
            




        }
        public Equipment GetEquipmentBySlot(EquipType d)
        {   
            return Equiped.First(e => e.Type == d);
        }
        /// <summary>
        /// ID is ItemID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>an equiment</returns>
        public Equipment GetEquipmentByItemID(int ID) 
        { 
            return Equiped.First(e=>e.ItemID == ID);
        }
        public void AddExp(int exp)
        {

            var oldlevel = level;
            CharExp += (ulong)exp;
          
            HasLeveled = oldlevel != level;
        }
        
    }
}







