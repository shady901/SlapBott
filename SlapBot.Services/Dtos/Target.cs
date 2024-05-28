using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace SlapBott.Services.Dtos
{
    public abstract class Target : IDisplayable, ITarget
    {
        private const double K = 100.0; // Constant for diminishing returns

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? RegionId { get; set; }
        public StatsDto? Stats { get; set; }
        public StatsDto? EquipedStats { get; set; }
        public int RaceID { get; set; }
        public int ClassID { get; set; }
        public RaceDto Race { get; set; }
        public List<int> Skills { get; set; } = new List<int>();
        public int StateId { get; set; } = 0;
        public CharacterClassDto? CharacterClass { get; set; }
        public SubClassDto? SubClass { get; set; }
        public ulong CharExp { get; set; }
        public int StatsId { get; set; }
        public int CombatStateId { get; set; } = 0;

        public int InventoryId { get; set; }
        public InventoryDto Inventory { get; set; }
        const double ResMax = .75;

        public int ApplyDamage(int damage, ElementalType elementalType)
        {
            double resistancePercentage = 1 - Math.Min((double)Stats.stats[ElementalAndStatTypeHelper.ReturnStatTypeByElementalType(elementalType)] / 100, ResMax);

            
            //reduce dmg by armor
            damage = (int)(damage * (1 - CalculateDamageReduction()));


            //reduce damage by resistance
            int finalDamage = (int)(resistancePercentage > 0 ? damage * resistancePercentage : damage);

            // Reduce the character's health by the final damage
            Stats.Health -= finalDamage;

            //return for later use in display
            return finalDamage;
        }


      
        public double CalculateDamageReduction()
        {
            // not including equip stats
            return Stats.ArmorRating / (Stats.ArmorRating + K);
        }

    }
}
