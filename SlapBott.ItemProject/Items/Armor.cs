using SlapBott.Data.Enums;
using SlapBott.ItemProject.Contracts;
using SlapBott.ItemProject.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SlapBott.ItemProject.Items
{
    public class Armor : Item
    {
        public ArmorType ArmorType { get; set; }
        public ArmorWeight Weight { get; set; }
        public int ArmorStat { get; set; }
        public int EvasonStat { get; set; }
        public double WeaponAttackSpeedModifer { get; set; }
        private Random _seededRandom;
        public Armor(Random random, int itemLevel, EquipType equipType, ArmorType armorType = ArmorType.None) : base(random, itemLevel, equipType)
        {
            _seededRandom = random;
            if (armorType != ArmorType.None)
            {
                ArmorType = armorType;
            }
            GetRandomArmorType();
            ModifyItemBasedOnLevel();
            ModifyArmorBasedOnLevel();
        }

        private void ModifyArmorBasedOnLevel()
        {
            ArmorStat = (int)( ArmorStat * ILevelModifier);
            EvasonStat = (int)( EvasonStat * ILevelModifier);
        }

        public void GetRandomArmorType()
        {
            ArmorWeight armorWeight = GetRandomWeight();

            if (ArmorType == ArmorType.None)
            {
                ArmorType[] WeightedTypes = armorWeight.GetArmorTypes();
                int index = _seededRandom.Next(0, WeightedTypes.Length);
                ArmorType = WeightedTypes[index];
            }




            PopulateArmorTypeFields(ArmorType);
        }

        private ArmorWeight GetRandomWeight()
        {           
            return (ArmorWeight)_seededRandom.Next(0, 3);
        }

        private void PopulateArmorTypeFields(ArmorType armor)
        {
            ArmorStat = armor.GetArmorStatAttribute();
            Weight = armor.GetWeightAttribute();
            EvasonStat = armor.GetEvasonStatAttribute();
            WeaponAttackSpeedModifer = armor.GetWeaponAttackSpeedModifierAttribute();
        }
    }
}
