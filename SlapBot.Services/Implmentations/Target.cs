using SlapBott.Data.Enums;
using SlapBott.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SlapBott.Data.Models
{
    public class Target : ITarget
    {
        public int Id { get; set; }
        public Stats Stats { get; set; }
        public Dictionary<string, Skill> Skills { get; set; }


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
