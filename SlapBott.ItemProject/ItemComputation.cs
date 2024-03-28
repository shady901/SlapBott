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
        private List<Type> _itemTypes = new List<Type>();
        private int _seed;
        public ItemComputation()
        {

        }

       

        public T GenerateItem<T>(int? seed, int? ItemLevel) where T : Item
        {
            
            SetSeededRandom(seed);
            Item item = new(_seedRandom, ItemLevel ?? 0);

            return SetupItem(item);
        }
        protected T SetupItem<T>(Item Item) where T : Item
        {
            var d = CastItem(Item);
            return d;
        }

        private T CastItem<T>(Item item) where T : Item
        {
          
            // if is main hand or off hand then it is a weapon
            if(item.EquipType == Data.Enums.EquipType.MainHand || item.EquipType == Data.Enums.EquipType.MainHand)
            {
                //this is a weapon
                return (T)(object) (item as Weapon);
            }
            return (T)(object)(item as Armor);
        
        }

        private void SetSeededRandom(int? seed)
        {
            _seed = (int)(seed ?? GenerateNewSeed());
            _seedRandom = new Random(_seed);
            
        }

        private int GenerateNewSeed()
        {
            return _random.Next(9999, int.MaxValue);
        }



    }
}
