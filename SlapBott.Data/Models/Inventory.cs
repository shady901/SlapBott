using SlapBott.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Models
{
    public class Inventory
    {
        public Dictionary<StatType,Equipment> Equiped { get; set; }
        public List<Equipment> Bag { get; set; }
        public List<Equipment> Bank { get; set; }

        private Item item;




        public int GetAllEquipedItemsStatsByStatType(StatType statType)
        {
            int stat = 0;
            if (Equiped.Count >= 1)
            {
                foreach (var pair in Equiped)
                {
                    stat +=  item.GenerateItem(pair.Value.Seed).GetStatByType(statType);

                }
            }
            return stat;
        }
    }
}
