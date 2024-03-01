using SlapBott.Data.Enums;

namespace SlapBott.Data.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public int ItemID { get; set; }
        public int CharID { get; set; }
        public ulong Seed { get; set; }
        public EquipType Type { get; set; }
        public int ItemLevel { get; set; }
        public int SlotID { get; set; }
        public int Count { get; set; }
       // public virtual ICollection<Crafted> Crafts { get; set; }
    }
}