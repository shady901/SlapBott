using System.ComponentModel.DataAnnotations.Schema;

namespace SlapBott.Data.Models
{
    public class InventoryItem
    {
        
        public int Id { get; set; }
        
        public int InventoryId { get; set; }

        [ForeignKey("InventoryId")]
        public virtual Inventory Inventory { get; set; }

        public int EquipmentId { get; set; }


        [ForeignKey("EquipmentId")]
        public virtual Item? Equipment { get; set; }
    }
}
