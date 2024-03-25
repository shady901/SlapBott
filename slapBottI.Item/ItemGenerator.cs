using SlapBott.ItemGenerator.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.ItemGenerator
{
    public class ItemGenerator
    {
        private Random _seedRandom;
        private List<Type> _itemTypes = new List<Type>();
       
        private int _itemLevel;



        public ItemGenerator() 
        {
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsSubclassOf(typeof(Item)))
                {
                    _itemTypes.Add(type);
                }
            }

        }
        private int GenerateNewSeed()
        { 
            Random random = new Random();
            return random.Next(9999, int.MaxValue);
        }
        private void SetRandomWithSeed(int? seed = null)
        {
            if (seed == null)
            {
                _seedRandom = new Random(GenerateNewSeed());
                return;
            }
            _seedRandom = new Random((int)seed);        
        }

        public Item GetItemBySeed(int? seed = null, int? ItemLevel = null)
        {
            SetRandomWithSeed(seed);
            SetPropertyItemLevel((int)(ItemLevel ?? 0));

            return GenerateItem();
            
        }

        public void SetPropertyItemLevel(int itemLevel)
        {
           _itemLevel = itemLevel;
        }

     
        private Item GenerateItem()
        {
          



        }
    }
}
