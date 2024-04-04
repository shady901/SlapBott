using SlapBott.Data.Enums;

namespace SlapBott.Data.Models
{
    public class Equipment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int ItemID { get; set; }      
        public int Seed { get; set; } 
        public EquipType EquipType { get; set; } = EquipType.None;
        public WeaponType WeaponType { get; set; } = WeaponType.None;
        public ArmorType ArmorType { get; set; } = ArmorType.None;
        public int DroppedLevel { get; set; }
        public int Count { get; set; }

       // public virtual ICollection<Crafted> Crafts { get; set; }
    }
}