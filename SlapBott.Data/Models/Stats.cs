using SlapBott.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Models
{
    public class Stats
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        [ForeignKey("CharacterId")]
        public virtual Character Character { get; set; }




        public Dictionary<StatType, int> stats { get; set; }

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




        public Stats()
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
        
    }
}
