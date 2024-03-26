using SlapBott.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.ItemProject.Enums
{
    public class AffixRangeAttribute : Attribute
    {
        public int Min { get; }
        public int Max { get; }
        public AffixRangeAttribute(int min, int max)
        {
            Min = min;
            Max = max;

        }
    }
    public enum WeaponPrefix
    {
        [AffixRange(0,1)]
        ArmorRating,        
        DodgeChance,       
        Dexterity,       
        Strength,       
        Intelligence,      
        AttackDamage,      
        CritChance,
        Health,        
        MaxHealth,
    }
    public enum ArmorPrefix
    {
        ArmorRating,
        DodgeChance,
        Dexterity,
        Strength,
        Intelligence,
        AttackDamage,
        CritChance,
        Health,
        MaxHealth,
    }
    public enum WeaponSuffix
    {
        FireResistance,
        FrostResistance,
        LightningResistance,
        PhysicalResistance,
        ChaosResistance,
        SpellPower,
        Speed,
        ElementalDamage,
        PhysicalDamage,
        ChaosDamage,
    }
    public enum ArmorSuffix 
    {
        FireResistance,
        FrostResistance,
        LightningResistance,
        PhysicalResistance,
        ChaosResistance,
        SpellPower,
        Speed,
        ElementalDamage,
        PhysicalDamage,
        ChaosDamage,
    }
}
