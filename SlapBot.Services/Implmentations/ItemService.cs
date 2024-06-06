using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.ItemProject;
using SlapBott.ItemProject.Builders;
using SlapBott.ItemProject.Contracts;
using SlapBott.ItemProject.Items;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Item = SlapBott.ItemProject.Items.Item;

namespace SlapBott.Services.Implmentations
{
    public class ItemService
    {
        private ItemComputation _itemComputation = new();
        public ItemService() 
        {
            
        
        }

        public T GenerateNewItem<T>(ItemParameters itemParameters) where T:Item
        {   
           return _itemComputation
               .GenerateItem<T>(itemParameters);
        }
        public Type GenerateRandomItemType()
        {
            Type[] types = new Type[] {typeof(Armor),typeof(Weapon)};
            Random random   = new Random();
           return types[random.Next(2)];
        }
       
      
    }
}
