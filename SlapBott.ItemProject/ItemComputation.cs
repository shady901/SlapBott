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
            Item item = new Item(_seedRandom,1);
            var witem = item.IsWeapon ? item.Cast<Weapon>() : item.Cast<Armor>();

        }

       

        public Item GenerateItem(int? seed, int? ItemLevel)
        {
            
            SetSeededRandom(seed);
          
            return SetupItem(SetItemType<Item>());
        }
        protected T SetupItem<T>(T Item) where T : Item
        {
            Item.seed = _seed;
            


            return Item;
        }

        private T SetItemType<T>() where T : Item
        {

            Type randomItemType = _itemTypes[_seedRandom.Next(_itemTypes.Count)];
            return (T)Activator.CreateInstance(randomItemType);
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
