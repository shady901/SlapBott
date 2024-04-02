using SlapBott.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.ItemProject.Extensions
{
    public static class WeaponTypeExtensions
    {
       
        public static WeaponType[] GetWeaponTypes(this Handed handed)
        {
            var weaponTypes = Enum.GetValues(typeof(WeaponType))
                .Cast<WeaponType>()
                .Where(w => w.GetHandedAttribute() == handed)
                .ToArray();

            return weaponTypes;
        }

      
        public static Handed GetHandedAttribute(this WeaponType weaponType)        {

            return SetMemberAndAttribute(weaponType)?.Handed ?? Handed.OneHanded; // Default to OneHanded if no attribute is found
        }
        public static int GetDamageAttribute(this WeaponType weaponType)        {
            
            return SetMemberAndAttribute(weaponType)?.BaseDamage ?? 0; // Default to OneHanded if no attribute is found
        }
        public static int GetAccuracyAttribute(this WeaponType weaponType)        {
            
            return SetMemberAndAttribute(weaponType)?.BaseAccuracy ?? 0; // Default to OneHanded if no attribute is found
        }
        public static double GetWeaponAttackSpeedAttribute(this WeaponType weaponType)        {
          
            return SetMemberAndAttribute(weaponType)?.WeaponAttackSpeed ?? 0; // Default to OneHanded if no attribute is found
        }
        private static WeaponTypeAttribute SetMemberAndAttribute(WeaponType weaponType)
        {
            var memberInfo = typeof(WeaponType).GetMember(weaponType.ToString()).FirstOrDefault();
            return memberInfo?.GetCustomAttribute<WeaponTypeAttribute>();

        }
    }
}
