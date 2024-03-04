using SlapBott.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Models
{
    public class Item
    {

        private Stats _stats { get; set; }

        public Item() { }
        public Item GenerateItem(ulong seed)
        {

            return new Item { _stats = new Stats { Strength = 1, Intelligence =1 ,Dexterity =1 } };
        }

        public int GetStatByType(StatType stat)
        {
            return _stats.stats[stat];
        }

    }
}
