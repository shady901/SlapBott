using SlapBott.Data.Enums;
using SlapBott.Data.Models;

namespace SlapBott.Services.Dtos
{
    public class InventoryDto
    {
        public Dictionary<StatType, Equipment> Equiped { get; set; }
        public List<Equipment> Bag { get; set; }
        public List<Equipment> Bank { get; set; }





        public int GetAllEquipedItemsStatsByStatType(StatType statType)
        {
            Item item = new();
            int stat = 0;
            if (Equiped.Count >= 1)
            {
                foreach (var pair in Equiped)
                {
                    stat += item.GenerateItem(pair.Value.Seed).GetStatByType(statType);

                }
            }
            return stat;
        }
    }
}