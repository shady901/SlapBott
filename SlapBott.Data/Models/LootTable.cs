using SlapBott.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlapBott.Data.Models
{
    public class LootTable
    {
        public int Id { get; set; }
        public int EnemyId { get; set; }

        public Enemy Enemy { get; set; }
        public ICollection<LootTableItem> LootTableItems { get; set; }
    }

    public class LootTableItem
    {
        public int Id { get; set; }
        public int LootTableId { get; set; }
        public LootTable LootTable { get; set; }

        public ItemType? ItemType { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public ItemRarety? GearRarety { get; set; }  // Only for gear items
    }



}
