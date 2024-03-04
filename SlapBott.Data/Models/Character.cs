
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
        public Stats Stats;
        public Inventory Inventory;
        public SubClass CharacterClass { get; set; }
       
        
        public Character()
        {
            




        }
      
        
    }
}







