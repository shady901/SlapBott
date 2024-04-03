using SlapBott.Data.Enums;
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
        private ItemComputation _itemComputation;
        public ItemService() 
        {
            
        
        }

        public object GetItemObjectBySeed(int? Seed = null, int? droppedLevel = null,WeaponType WeaponType = WeaponType.None,ArmorType ArmorType= ArmorType.None)
        {   
           return _itemComputation
               .GenerateItem(
               seed:Seed,
               DroppedLevel:droppedLevel,
               weaponType: WeaponType,
               armorType:ArmorType
               );
        }

        

    }
}
