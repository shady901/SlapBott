using SlapBott.Data.Enums;

namespace SlapBott.Data.Models
{
    public abstract class Item
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        
        public int FoundLevel { get; set; }
        public EnemyTypes? EnemyType { get; set; }        
        public AreaType? AreaType { get; set; }
        public Regions? Regions { get; set; }
        public GatheringType? AcuiredThroughType { get; set; }
    }
}