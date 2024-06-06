using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Models
{
    public class LootTable
    {
        public int Id { get; set; }

        public List<LootableItem> lootableItems { get; set; }

    }

    public class LootableItem
    { 
        public int id { get; set; }
        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        public virtual BaseItem BaseItem { get; set; }
        public int DropChance { get; set; }
    
    
    }


    public class BaseItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsConsumable { get; set; }
        public bool IsMateral { get; set; }
        //used in ??? proffessions make it easier to make calls/sortby
    }
}
