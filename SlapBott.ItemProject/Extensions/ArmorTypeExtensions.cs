using SlapBott.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.ItemProject.Extensions
{
    public static class ArmorTypeExtensions
    {
        public static ArmorType[] GetArmorTypes(this ArmorWeight armorWeight)
        {
            var ArmorTypes = Enum.GetValues(typeof(ArmorType))
                .Cast<ArmorType>()
                .Where(w => w.GetWeightAttribute() == armorWeight)
                .ToArray();

            return ArmorTypes;
        }


        public static ArmorWeight GetWeightAttribute(this ArmorType armorType)
        {

            return SetMemberAndAttribute(armorType)?.ArmorWeight ?? ArmorWeight.Heavy; 
        }
        public static int GetArmorStatAttribute(this ArmorType armorType)
        {

            return SetMemberAndAttribute(armorType)?.BaseArmor ?? 0; 
        }
        public static int GetEvasonStatAttribute(this ArmorType armorType)
        {

            return SetMemberAndAttribute(armorType)?.BaseEvasion ?? 0; 
        }
        public static double GetWeaponAttackSpeedModifierAttribute(this ArmorType armorType)
        {

            return SetMemberAndAttribute(armorType)?.WeaponAttackSpeedModifier ?? 0; 
        }
        private static ArmorTypeAttribute SetMemberAndAttribute(ArmorType armorType)
        {
            var memberInfo = typeof(ArmorType).GetMember(armorType.ToString()).FirstOrDefault();
            return memberInfo?.GetCustomAttribute<ArmorTypeAttribute>();

        }
    }
}
