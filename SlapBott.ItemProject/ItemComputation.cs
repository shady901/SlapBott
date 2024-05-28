using SlapBott.Data.Enums;
using SlapBott.ItemProject.Items;


namespace SlapBott.ItemProject
{
    public class ItemComputation
    {
        private Random _random = new Random();
        private Random _seedRandom;
     
        
        public ItemComputation()
        {

        }

        private EquipType GenerateEquipType()
        {
           return (EquipType)_seedRandom.Next(1, 7);
        }

        public object GenerateItem(int? seed = null, int? DroppedLevel = null, WeaponType weaponType = WeaponType.None, ArmorType armorType = ArmorType.None)
        {
           seed = SetSeededRandom(seed);
            var equipedType = GenerateEquipType();
            Type ItemType = GetTypeFromEquipType(equipedType);
            if (ItemType ==typeof(Weapon))
            {
                return Activator.CreateInstance(ItemType, _seedRandom, DroppedLevel, equipedType, weaponType,seed);
            }
            return Activator.CreateInstance(ItemType, _seedRandom, DroppedLevel, equipedType, armorType,seed);
        }
        


        private Type GetTypeFromEquipType(EquipType equip)
        {
            switch (equip)
            {
                case EquipType.MainHand:
                    return typeof(Weapon);
                case EquipType.OffHand:
                    return typeof(Weapon);
                default:
                    return typeof(Armor);
            }
        }
        private int SetSeededRandom(int? seed)
        {
            int _seed = seed ?? GenerateNewSeed();
            _seedRandom = new Random(_seed);
            return _seed;
        }
        private int GenerateNewSeed()
        {
            return _random.Next(9999, int.MaxValue);
        }

        

    }
}
