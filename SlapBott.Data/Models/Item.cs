using SlapBott.Data.Enums;

namespace SlapBott.Data.Models
{
    public class Item
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        //ItemID as in what type
        public int ItemID { get; set; }      
        public int Seed { get; set; } 
        
        public int DroppedLevel { get; set; }
        public int Count { get; set; }

       // public virtual ICollection<Crafted> Crafts { get; set; }
    }
}