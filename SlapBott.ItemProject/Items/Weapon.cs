using SlapBott.Data.Enums;
using SlapBott.ItemProject.Builders;
using SlapBott.ItemProject.Contracts;
using SlapBott.ItemProject.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace SlapBott.ItemProject.Items
{
    public class Weapon : Gear
    {

        public int Damage { get; set; }
        public WeaponType WeaponType { get; set; }
        public int Accuracy { get; set; }
        public double AttackSpeed { get; set; }
        public Handed Handed { get; set; }
        private Random _seededRandom;
        
        public Weapon(Random random, EquipType equipType, ItemParameters itemParameters) : base(random,equipType,itemParameters)
        {
            WeaponType  = itemParameters.WeaponType?? WeaponType.None;

            _seededRandom = random;
            
            GetRandomWeaponTypeBasedOnEquipType();



            ModifyItemBasedOnLevel();
            ModifyWeaponBasedOnLevel();
        }
        
        private void GetRandomWeaponTypeBasedOnEquipType()
        {
            switch (EquipType)
            {
                case EquipType.MainHand:
                    AssignWeaponTypeByHandedAndPopulateFields(_seededRandom.Next(1, 3) == 1 ? Handed.OneHanded : Handed.TwoHanded);
                    break;
                case EquipType.OffHand:
                    AssignWeaponTypeByHandedAndPopulateFields(Handed.OneHanded);
                    break;
                default:
                    break;
            }
        }
        private void AssignWeaponTypeByHandedAndPopulateFields(Handed handed)
        {
            if (WeaponType == WeaponType.None)
            {
                WeaponType[] HandedTypes = handed.GetWeaponTypes();
                int index = _seededRandom.Next(0, HandedTypes.Length);               
                WeaponType = HandedTypes[index];
            }
            
                
            
          
            PopulateWeaponTypeFields(WeaponType);
        }

        private void PopulateWeaponTypeFields(WeaponType weaponType)
        {
            Handed = weaponType.GetHandedAttribute();
            Accuracy = weaponType.GetAccuracyAttribute();
            Damage = weaponType.GetDamageAttribute();
            AttackSpeed = weaponType.GetWeaponAttackSpeedAttribute();
        }

        private void ModifyWeaponBasedOnLevel()
        {
          
            Damage = (int)(Damage * ILevelModifier);
            Accuracy = (int)(Accuracy * ILevelModifier);
        }
        
        

     
    }
}
