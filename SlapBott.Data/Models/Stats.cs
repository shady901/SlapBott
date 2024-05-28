﻿using SlapBott.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;


namespace SlapBott.Data.Models
{
    public class Stats
    {
        public int Id { get; set; }
 
        //public virtual Character Character { get; set; }

        public Dictionary<StatType, int> stats { get; set; }

        public HashSet<StatType> resistanceTypes = new HashSet<StatType>
            {
                StatType.FireResistance,
                StatType.ChaosResistance,
                StatType.FrostResistance,
                StatType.LightningResistance,
                StatType.PhysicalResistance
            };
        [NotMapped]
        public int Health
        {
            get => stats[StatType.Health];
            set => stats[StatType.Health] = value;
        }
        [NotMapped]
        public int MaxHealth
        {
            get => stats[StatType.MaxHealth];
            set => stats[StatType.MaxHealth] = value;
        }
        [NotMapped]
        public int Strength
        {
            get => stats[StatType.Strength];
            set => stats[StatType.Strength] = value;
        }
        [NotMapped]
        public int Dexterity
        {
            get => stats[StatType.Dexterity];
            set => stats[StatType.Dexterity] = value;
        }
        [NotMapped]
        public int Intelligence
        {
            get => stats[StatType.Intelligence];
            set => stats[StatType.Intelligence] = value;
        }
        [NotMapped]
        public int CritChance 
        {
            get => stats[StatType.CritChance]; 
            set => stats[StatType.CritChance] = value;
        }
        [NotMapped]
        
     
        public int SpellPower 
        { 
            get => stats[StatType.SpellPower]; 
            set => stats[StatType.SpellPower] = value; 
        }
        [NotMapped]
        public int ChaosResistance
        {
            get => stats[StatType.ChaosResistance];
            set => stats[StatType.ChaosResistance] = value;
        }
        [NotMapped]
        public int FireResistance
        {
            get => stats[StatType.FireResistance];
            set => stats[StatType.FireResistance] = value;
        }
        [NotMapped]
        public int PhysicalResistance
        {
            get => stats[StatType.PhysicalResistance];
            set => stats[StatType.PhysicalResistance] = value;
        }
        [NotMapped]
        public int FrostResistance
        {
            get => stats[StatType.FrostResistance];
            set => stats[StatType.FrostResistance] = value;
        }
        [NotMapped]
        public int LightningResistance
        {
            get => stats[StatType.LightningResistance];
            set => stats[StatType.LightningResistance] = value;
        }
        [NotMapped]
        public int ArmorRating
        {
            get => stats[StatType.ArmorRating];
            set => stats[StatType.ArmorRating] = value;
        }
        [NotMapped]
        public int DodgeChance
        {
            get => stats[StatType.DodgeChance];
            set => stats[StatType.DodgeChance] = value;
        }
        [NotMapped]
        public int PhysicalPower
        {
            get => stats[StatType.PhysicalPower];
            set => stats[StatType.PhysicalPower] = value;
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
               {StatType.ArmorRating,0},
               {StatType.DodgeChance,0 },
                
               //%'s----------------
               {StatType.ChaosResistance,0},
               {StatType.FireResistance,0},
               {StatType.PhysicalResistance,0},
               {StatType.FrostResistance,0},
               {StatType.LightningResistance,0},
               {StatType.SpellPower,0},
               {StatType.PhysicalPower,0},
               {StatType.ElementalDamage,0},
               {StatType.Speed,0},
               {StatType.ChaosDamage,0},
      

            };

        }

      
    }
}
