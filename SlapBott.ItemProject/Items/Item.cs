using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.ItemProject.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SlapBott.ItemProject.Items
{
    public class Item : IItem
    {
        public  int seed { get; set; }
        public int Itemlevel { get; set; }
        public  string? name { get; set; }
        public  EquipType EquipType { get; set; }
        public bool IsWeapon => (EquipType == EquipType.MainHand || EquipType == EquipType.OffHand);
        public  ItemRarety itemRarety { get; set; }
        public List<ItemAffix> itemAffixes { get; set; } = new();
       
        private Random _seededRandom;
        private Dictionary<ItemRarety, double> _rarityProbabilities = new Dictionary<ItemRarety, double>
          {
           { ItemRarety.Normal, 0.4 },    // 40% chance
           { ItemRarety.Uncommon, 0.3 },  // 30% chance
           { ItemRarety.Rare, 0.2 },      // 20% chance
           { ItemRarety.Epic, 0.07 },     // 7% chance
           { ItemRarety.Legendary, 0.03 } // 3% chance
          };
        private Dictionary<ItemRarety, int> _rarityAffixCounts = new Dictionary<ItemRarety, int>
          {
           { ItemRarety.Normal, 2 },  
           { ItemRarety.Uncommon, 3 }, 
           { ItemRarety.Rare, 4 },     
           { ItemRarety.Epic, 5 },     
           { ItemRarety.Legendary, 6 } 
          };
        public Item(Random random, int itemLevel)
        { 
            Itemlevel = itemLevel;
            _seededRandom = random;
            itemRarety = GenerateItemRarety();
            GenerateEquipType();
            GenerateItemAffixes();
            ModifyItemBasedOnLevel();
        }


        public T Cast<T>() where T : Item
        {
            return (T)this;
        }
        
        private void GenerateEquipType()
        {
            EquipType = (EquipType)_seededRandom.Next(1, 7);
        }

        private void ModifyItemBasedOnLevel()
        {
            throw new NotImplementedException();
        }
        private void GenerateItemAffixes()
        {
            int totalAffixes = GetAffixAmountBasedOnRarety();
            int prefixCount = totalAffixes / 2 + totalAffixes % 2;
            int suffixCount = totalAffixes - prefixCount;

            for (int i = 0; i < prefixCount; i++) { itemAffixes.Add(new ItemAffix(itemRarety,IsWeapon,_seededRandom,AffixType.Prefix).GenerateItemAffix()); }
            for (int i = 0; i < prefixCount; i++) { itemAffixes.Add(new ItemAffix(itemRarety, IsWeapon, _seededRandom, AffixType.Suffix).GenerateItemAffix()); }


        }

        private int GetAffixAmountBasedOnRarety()
        {
           return _rarityAffixCounts[itemRarety];
        }

        private ItemRarety GenerateItemRarety()
        {
            double randomValue = _seededRandom.NextDouble(); // Generate a random value between 0 and 1

            // Determine rarity based on the cumulative probabilities
            foreach (var kvp in _rarityProbabilities)
            {
                if (randomValue < kvp.Value)
                {
                    return kvp.Key;
                }
                randomValue -= kvp.Value;
            }

            // Fallback to the last rarity if randomValue is greater than 1
            return _rarityProbabilities.Keys.Last();
        }
    }
}
