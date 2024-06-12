﻿using SlapBott.Data.Enums;
using SlapBott.ItemProject.Builders;
using SlapBott.ItemProject.Contracts;
using System;



namespace SlapBott.ItemProject.Items
{
    public class Gear : IItem
    {
        public  int Seed { get; set; }
        public int ItemLevel { get; set; }
        public required string Name { get; set; } = "NotSetup";
        public string Description { get; set; }
        public  EquipType EquipType { get; set; }
        public bool IsWeapon => (EquipType == EquipType.MainHand || EquipType == EquipType.OffHand);
        public  ItemRarety itemRarety { get; set; }
        public List<ItemAffix> itemAffixes { get; set; } = new();


        public double IlevelRatio = 0.01;
        public int DroppedLevel;
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
        
        protected double ILevelModifier { get; set; }
        
        public Gear(Random random,EquipType equipType, ItemParameters itemParameters)
        {

            DroppedLevel = itemParameters.DroppedLevel??0;
            EquipType = equipType;            
            _seededRandom = random;
            Seed = itemParameters.Seed??0;
            itemRarety = itemParameters.ItemRarety ?? GenerateItemRarety();
            ItemLevel = CalculateItemLevelOfDroppedLevel();
            GenerateItemAffixes();
            ILevelModifier = (1 + ((ItemLevel / 5) * IlevelRatio));
            ModifyItemBasedOnLevel();   
          
        }

        private int CalculateItemLevelOfDroppedLevel()
        {
            if (DroppedLevel > 1)
            {
                return _seededRandom.Next(DroppedLevel - 1, DroppedLevel + 2) * 5;
            }
            return _seededRandom.Next(1, 3) * 5;
        }

        protected void ModifyItemBasedOnLevel()
        {           
            foreach (var item in itemAffixes)
            {
                item.StatValue = (int)(item.StatValue * ILevelModifier);
            }
        }
        private void GenerateItemAffixes()
        {
            int totalAffixes = GetAffixAmountBasedOnRarety();
            int prefixCount = totalAffixes / 2 + totalAffixes % 2;
            int suffixCount = totalAffixes - prefixCount;

            for (int i = 0; i < prefixCount; i++) { itemAffixes.Add(new ItemAffix(itemRarety,IsWeapon,_seededRandom,AffixType.Prefix).GenerateItemAffix()); }
            for (int i = 0; i < suffixCount; i++) { itemAffixes.Add(new ItemAffix(itemRarety, IsWeapon, _seededRandom, AffixType.Suffix).GenerateItemAffix()); }


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