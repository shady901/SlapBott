using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Enums
{
    public class ArmorTypeAttribute : Attribute
    {
        public ArmorWeight ArmorWeight { get; set; }
        public int BaseArmor { get; set; }
        public int BaseEvasion { get; set; }
        public double WeaponAttackSpeedModifier { get; set; }
        public ArmorTypeAttribute(ArmorWeight armorWeight, int baseArmor, int baseEvasion, double weaponAttackSpeedModifier)
        {
            WeaponAttackSpeedModifier = weaponAttackSpeedModifier;
            ArmorWeight = armorWeight;
            BaseArmor = baseArmor;
            BaseEvasion = baseEvasion;
        }
    }
    public enum ArmorType
    {
        None,

        [ArmorType(ArmorWeight.Heavy,1,1,0.1)]
        PlateMail,


        [ArmorType(ArmorWeight.Medium, 1, 1, 0.1)]
        ElvenSteel,


        [ArmorType(ArmorWeight.Light, 1, 1, 0.1)]
        Leather,
        [ArmorType(ArmorWeight.Light, 1, 1, 0.1)]
        Cloth,

    }

    public enum ArmorWeight
    { 
        Heavy,        
        Medium,
        Light,
    }
}
