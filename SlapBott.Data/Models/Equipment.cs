using SlapBott.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlapBott.Data.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public int MaterialId { get; set; } = 0;
        public int ConsumableId { get; set; } = 0;
        [ForeignKey("MaterialId")]
        public Material? Material { get; set; }
        [ForeignKey("ConsumableId")]
        public Consumable? Consumable { get; set; }
        public int Seed { get; set; } 
        public EquipType EquipType { get; set; }   
        public WeaponType WeaponType { get; set; }
        public ArmorType ArmorType { get; set; }
        public int DroppedLevel { get; set; }
        public int Count { get; set; }

       // public virtual ICollection<Crafted> Crafts { get; set; }
    }
}