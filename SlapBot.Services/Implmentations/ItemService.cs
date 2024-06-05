using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.ItemProject;
using SlapBott.ItemProject.Contracts;
using SlapBott.ItemProject.Items;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Implmentations
{
    public class ItemService
    {
        private ItemComputation _itemComputation = new();
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

        public Stats GetAllStatsOnItems(List<Data.Models.Item> equiped) 
        {
            Stats stats = new Stats();
            foreach (Data.Models.Item item in equiped)
            {
                object temp = _itemComputation.GenerateItem(item.Seed, item.DroppedLevel, item.WeaponType, item.ArmorType);
                if (temp is Weapon weapon)
                {
                    foreach (var itemAffix in weapon.itemAffixes)
                    {
                        if (stats.stats.ContainsKey(itemAffix.StatType))
                        {
                            stats.stats[itemAffix.StatType] += itemAffix.StatValue;
                        }                       
                    }
                }
                else if (temp is Armor armor)
                {
                    foreach (var itemAffix in armor.itemAffixes)
                    {
                        if (stats.stats.ContainsKey(itemAffix.StatType))
                        {
                            stats.stats[itemAffix.StatType] += itemAffix.StatValue;
                        }                        
                    }
                }
            }
            return stats;
        }

    }
}
