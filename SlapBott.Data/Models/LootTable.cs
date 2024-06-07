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


        public virtual List<LootTableItem>? LootableItems { get; set; }

    }

    public class LootTableItem
    { 
        public int id { get; set; }
        public int ItemId { get; set; }
        
    //    [ForeignKey("ItemId")]
    //    public virtual BaseItem? BaseItem { get; set; }
        public int DropChance { get; set; }
        public int Amount { get; set; }
    
    
    }


    
}
