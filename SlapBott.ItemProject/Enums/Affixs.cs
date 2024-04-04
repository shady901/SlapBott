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
        [AffixRange(0, 1)]
        DodgeChance,
        [AffixRange(0, 1)]
        Dexterity,
        [AffixRange(0, 1)]
        Strength,
        [AffixRange(0, 1)]
        Intelligence,
        [AffixRange(0, 1)]
        AttackDamage,
        [AffixRange(0, 1)]
        CritChance,
        [AffixRange(0, 1)]
        Health,
        [AffixRange(0, 1)]
        MaxHealth,
    }
    public enum WeaponSuffix
    {
        [AffixRange(0, 1)]
        FireResistance,
        [AffixRange(0, 1)]
        FrostResistance,
        [AffixRange(0, 1)]
        LightningResistance,
        [AffixRange(0, 1)]
        PhysicalResistance,
        [AffixRange(0, 1)]
        ChaosResistance,
        [AffixRange(0, 1)]
        SpellPower,
        [AffixRange(0, 1)]
        Speed,
        [AffixRange(0, 1)]
        ElementalDamage,
        [AffixRange(0, 1)]
        PhysicalDamage,
        [AffixRange(0, 1)]
        ChaosDamage,
    }

    public enum ArmorPrefix
    {
        [AffixRange(0, 1)]
        ArmorRating,
        [AffixRange(0, 1)]
        DodgeChance,
        [AffixRange(0, 1)]
        Dexterity,
        [AffixRange(0, 1)]
        Strength,
        [AffixRange(0, 1)]
        Intelligence,
        [AffixRange(0, 1)]
        AttackDamage,
        [AffixRange(0, 1)]
        CritChance,
        [AffixRange(0, 1)]
        Health,
        [AffixRange(0, 1)]
        MaxHealth,
    }
    public enum ArmorSuffix
    {
        [AffixRange(0, 1)]
        FireResistance,
        [AffixRange(0, 1)]
        FrostResistance,
        [AffixRange(0, 1)]
        LightningResistance,
        [AffixRange(0, 1)]
        PhysicalResistance,
        [AffixRange(0, 1)]
        ChaosResistance,
        [AffixRange(0, 1)]
        SpellPower,
        [AffixRange(0, 1)]
        Speed,
        [AffixRange(0, 1)]
        ElementalDamage,
        [AffixRange(0, 1)]
        PhysicalDamage,
        [AffixRange(0, 1)]
        ChaosDamage,
    }
   
}
