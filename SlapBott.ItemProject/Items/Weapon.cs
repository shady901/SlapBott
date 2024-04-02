using SlapBott.Data.Enums;
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
    public class Weapon : Item
    {

        public int Damage { get; set; }
        public WeaponType WeaponType { get; set; }
        public int Accuracy { get; set; }
        public double AttackSpeed { get; set; }
        public Handed Handed { get; set; }
        private Random _seededRandom;
        
        public Weapon(Random random, int DroppedLevel, EquipType equipType) : base(random, DroppedLevel, equipType)
        {
            _seededRandom = random;

            GetRandomWeaponTypeBasedOnEquipType();



            ModifyItemBasedOnLevel();
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
            bool Found = false;
            WeaponType[] HandedTypes = handed.GetWeaponTypes();
            while (!Found)
            {
                int index = _seededRandom.Next(1,201);
                if (index  <= HandedTypes.Length)
                {
                    WeaponType = HandedTypes[index];
                    Found = true;
                }
                
            }
          
            PopulateWeaponTypeFields(WeaponType);
        }

        private void PopulateWeaponTypeFields(WeaponType weaponType)
        {
            Accuracy = weaponType.GetAccuracyAttribute();
            Damage = weaponType.GetDamageAttribute();
            AttackSpeed = weaponType.GetWeaponAttackSpeedAttribute();
        }

        internal override void ModifyItemBasedOnLevel()
        {
            double Modifier = (1 + ((ItemLevel / 5) * IlevelRatio));
            base.ModifyItemBasedOnLevel();
            Damage = (int)(Damage * Modifier);
            Accuracy = (int)(Accuracy * Modifier);
        }
        

     
    }
}
