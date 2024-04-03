using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Enums
{

    public class WeaponTypeAttribute : Attribute
    {
        public Handed Handed { get; set; }
        public int BaseDamage { get; set; }
        public int BaseAccuracy { get; set; }
        public double WeaponAttackSpeed { get; set; }
        public WeaponTypeAttribute(Handed handed, int basedamage, int baseAccuracy, double weaponAttackSpeed)
        {
            WeaponAttackSpeed = weaponAttackSpeed;
            Handed = handed;
            BaseAccuracy = baseAccuracy;
            BaseDamage = basedamage;
        }
    }
    public enum WeaponType
    {
        None = 0,

        [WeaponType(Handed.OneHanded,1,1,1)]
        Dagger,
        [WeaponType(Handed.OneHanded, 1, 1, 1)]
        Sword,
        [WeaponType(Handed.OneHanded, 1, 1, 1)]
        Wand,
        [WeaponType(Handed.OneHanded, 1, 1, 1)]
        Shield,
        [WeaponType(Handed.OneHanded, 1, 1, 1)]
        SpellTome,


        //Two Handed
        [WeaponType(Handed.TwoHanded, 1, 1, 1)]
        Staff,
        [WeaponType(Handed.TwoHanded, 1, 1, 1)]
        BroadSword,
        [WeaponType(Handed.TwoHanded, 1, 1, 1)]
        Bow,

    }
    public enum Handed
    { 
        OneHanded,
        TwoHanded,
    }
}
