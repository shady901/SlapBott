
using SlapBott.Data.Models;

namespace SlapBott.Services.Dtos
{
    public class ConsumableDto : ItemDto
    {
        public ConsumableDto FromRecord(Consumable? consumable = null)
        {
            if (consumable == null)
            {
                consumable = new Consumable() { Name = string.Empty};
            }

            Name = consumable.Name;
            Description = consumable.Description;
            FoundLevel = consumable.FoundLevel;
            EnemyType = consumable.EnemyType;
            AreaType = consumable.AreaType;
            Regions = consumable.Regions;
            AcuiredThroughType = consumable.AcuiredThroughType;

            return this;

        }
        public Consumable ToRecord(Consumable? consumable = null)
        {
            if (consumable == null)
            {
                consumable = new Consumable() { Name = string.Empty };
            }

            consumable.Name = Name;
            consumable.Description = Description;
            consumable.FoundLevel = FoundLevel;
            consumable.EnemyType = EnemyType;
            consumable.AreaType = AreaType;
            consumable.Regions = Regions;
            consumable.AcuiredThroughType = AcuiredThroughType;

            return consumable;
        }
    }
}

