using SlapBott.Data.Enums;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlapBott.Data.Models
{
    public class Inventory
    {
        public Inventory()
        {
            Items = new List<InventoryItem>();
        }

        public int Id { get; set; }
        public int CharacterId { get; set; }
        [ForeignKey("CharacterId")]
        public virtual Character? Character { get; set; }

        public virtual Dictionary<EquipType,Item>? Equiped { get; set; }
        
        public virtual List<InventoryItem> Items { get; set; }
      

    }
}
