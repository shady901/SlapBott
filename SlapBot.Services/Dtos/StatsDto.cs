using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
    public class StatsDto
    {
        
        public Dictionary<StatType, int> stats { get; set; }

        public HashSet<StatType> resistanceTypes = new HashSet<StatType>
        {
            StatType.FireResistance,
            StatType.ChaosResistance,
            StatType.FrostResistance,
            StatType.LightningResistance,
            StatType.PhysicalResistance
        };
        public StatsDto()
        {
            stats = new Dictionary<StatType, int>()
            {
               {StatType.Dexterity, 0},
               {StatType.Strength, 0},
               {StatType.Intelligence,0},
               {StatType.CritChance,0},
               {StatType.MaxHealth,0},
               {StatType.Health,0},
               {StatType.AttackDamage,0},
               {StatType.ArmorRating,0},
               {StatType.DodgeChance,0 },
                
               //%'s----------------
               {StatType.ChaosResistance,0},
               {StatType.FireResistance,0},
               {StatType.PhysicalResistance,0},
               {StatType.FrostResistance,0},
               {StatType.LightningResistance,0},
               {StatType.SpellPower,0},
               {StatType.PhysicalDamage,0},
               {StatType.ElementalDamage,0},
               {StatType.Speed,0},
               {StatType.ChaosDamage,0},
            };

        }
        public StatsDto FromStats(Stats Stats)
        {
            stats = Stats.stats;
            return this;
        }
        public Stats ToStats(Stats? stats = null)
        {
            if (stats == null)
            {
                stats = new();
            }
            stats.stats = this.stats;
            return stats;
        }
        #region Stats
        public int Health
        {
            get => stats[StatType.Health];
            set => stats[StatType.Health] = value;
        }
        public int MaxHealth
        {
            get => stats[StatType.MaxHealth];
            set => stats[StatType.MaxHealth] = value;
        }
        public int Strength
        {
            get => stats[StatType.Strength];
            set => stats[StatType.Strength] = value;
        }
        public int Dexterity
        {
            get => stats[StatType.Dexterity];
            set => stats[StatType.Dexterity] = value;
        }
        public int Intelligence
        {
            get => stats[StatType.Intelligence];
            set => stats[StatType.Intelligence] = value;
        }
        public int CritChance
        {
            get => stats[StatType.CritChance];
            set => stats[StatType.CritChance] = value;
        }
       public int AttackDamage
        {
            get => stats[StatType.AttackDamage];
            set => stats[StatType.AttackDamage] = value;
        }
        public int SpellPower
        {
            get => stats[StatType.SpellPower];
            set => stats[StatType.SpellPower] = value;
        }
        public int ChaosResistance
        {
            get => stats[StatType.ChaosResistance];
            set => stats[StatType.ChaosResistance] = value;
        }
       public int FireResistance
        {
            get => stats[StatType.FireResistance];
            set => stats[StatType.FireResistance] = value;
        }
         public int PhysicalResistance
        {
            get => stats[StatType.PhysicalResistance];
            set => stats[StatType.PhysicalResistance] = value;
        }
        public int FrostResistance
        {
            get => stats[StatType.FrostResistance];
            set => stats[StatType.FrostResistance] = value;
        }
        public int LightningResistance
        {
            get => stats[StatType.LightningResistance];
            set => stats[StatType.LightningResistance] = value;
        }
        public int ArmorRating
        {
            get => stats[StatType.ArmorRating];
            set => stats[StatType.ArmorRating] = value;
        }
        public int DodgeChance
        {
            get => stats[StatType.DodgeChance];
            set => stats[StatType.DodgeChance] = value;
        }
        #endregion

        public StatsDto InitialiseRaidBossStats()
        {
            Dictionary<StatType, int> Temp = new();
            foreach (var stat in stats)
            {
                int modifiedValue = stat.Value * 10;
                if (resistanceTypes.Contains(stat.Key))
                {
                    modifiedValue = 75;
                }
                Temp.Add(stat.Key, modifiedValue);
            }
            stats = Temp;
            return this;
        }

    }
}
