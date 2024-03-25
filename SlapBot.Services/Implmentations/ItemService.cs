using SlapBott.ItemProject;
using SlapBott.ItemProject.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Implmentations
{
    public class ItemService
    {
        private ItemComputation _itemGenerator = new();
        public ItemService() 
        {
            
        
        }

        public Item GetItemBySeed(int? Seed = null, int? ItemLevel = null)
        {
            return _itemGenerator.GenerateItem(Seed, ItemLevel);        
        }

        

    }
}
