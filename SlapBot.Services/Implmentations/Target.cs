using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Services.Contracts;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace SlapBott.Services.Implmentations
{
    public abstract class Target: ITarget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? RegionId { get; set; }
        public Stats? Stats { get; set; }
        public int RaceID { get; set; }
        public int ClassID { get; set; }
        public RaceDto Race { get; set; }
        public CharacterClassDto CharacterClassDto { get; set; }
        public List<int> Skills { get; set; } = new List<int>();
        public int StateId { get; set; }
        public InventoryDto Inventory { get; set; }
        const double ResMax = .75;

        public void ApplyDamage(int damage, StatType elementalType)
        {

            double resistancePercentage = 1 - Math.Min((double)Stats.stats[elementalType] / 100, ResMax);

            // Calculate the final damage after applying resistance
            int finalDamage =(int)(resistancePercentage > 0 ? damage * resistancePercentage : damage);

            // Reduce the character's health by the final damage
            Stats.Health -= finalDamage;


           
        }
        

    }
}
