using SlapBott.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.ItemProject.Builders
{
    public class ItemParameters
    {
        public int? Seed { get;  set; }
        public int? DroppedLevel { get;  set; }
        public WeaponType? WeaponType { get;  set; }
        public ArmorType? ArmorType { get;  set; }
        public ItemRarety? ItemRarety { get;  set; }

        public ItemParameters(int? seed, int? droppedLevel, WeaponType? weaponType, ArmorType? armorType, ItemRarety? itemRarety)
        {
            Seed = seed;
            DroppedLevel = droppedLevel;
            WeaponType = weaponType;
            ArmorType = armorType;
            ItemRarety = itemRarety;
        }
    }

    public class ItemParameterBuilder
    {
        private int? _seed = null;
        private int? _droppedLevel = null;
        private WeaponType? _weaponType = null;
        private ArmorType? _armorType = null;
        private ItemRarety? _ItemRarety = null;

        public ItemParameterBuilder WithSeed(int? seed)
        {
           _seed = seed;
            return this;
        }

        public ItemParameterBuilder WithDroppedLevel(int? droppedLevel)
        {
            _droppedLevel = droppedLevel;
            return this;
        }

        public ItemParameterBuilder WithWeaponType(WeaponType? weaponType)
        {
            _weaponType = weaponType;
            return this;
        }

        public ItemParameterBuilder WithArmorType(ArmorType? armorType)
        {
            _armorType = armorType;
            return this;
        }

        public ItemParameterBuilder WithItemRarety(ItemRarety? itemRarety)
        {
            _ItemRarety = itemRarety;
            return this;
        }

        public ItemParameters Build()
        {
            return new ItemParameters(_seed, _droppedLevel, _weaponType, _armorType, _ItemRarety);
        }
    }

}
