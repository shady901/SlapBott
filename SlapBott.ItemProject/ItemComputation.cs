using SlapBott.Data.Enums;
using SlapBott.ItemProject.Contracts;
using SlapBott.ItemProject.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

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

        public object GenerateItem(int? seed = null, int? DroppedLevel = null)
        {
            SetSeededRandom(seed);
            var equipedType = GenerateEquipType();
            Type ItemType = GetTypeFromEquipType(equipedType);
            return Activator.CreateInstance(ItemType, _seedRandom, DroppedLevel, equipedType);           
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
        private void SetSeededRandom(int? seed)
        {
           int _seed = (int)(seed ?? GenerateNewSeed());
            _seedRandom = new Random(_seed);
            
        }
        private int GenerateNewSeed()
        {
            return _random.Next(9999, int.MaxValue);
        }



    }
}
