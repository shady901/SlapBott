using SlapBott.Data.Enums;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        [ForeignKey("CharacterId")]
        public virtual Character Character { get; set; }
        public Dictionary<EquipType,Equipment> Equiped { get; set; }
        public ICollection<Equipment> Bag { get; set; }
      
    }
}
