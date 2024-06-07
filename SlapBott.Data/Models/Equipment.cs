using SlapBott.Data.Enums;

namespace SlapBott.Data.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        //ItemID as in what type
        public int ItemID { get; set; }      
        public int Seed { get; set; } 
        public EquipType EquipType { get; set; }   
        public WeaponType WeaponType { get; set; }
        public ArmorType ArmorType { get; set; }
        public int DroppedLevel { get; set; }
        public int Count { get; set; }

       // public virtual ICollection<Crafted> Crafts { get; set; }
    }
}