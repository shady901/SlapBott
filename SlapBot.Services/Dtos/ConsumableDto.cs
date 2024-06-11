
using SlapBott.Data.Models;

namespace SlapBott.Services.Dtos
{
    public class ConsumableDto : ItemDto
    {
        public ConsumableDto FromConsumeable(Consumable material)
        {

            Name = material.Name;
            Description = material.Description;
            FoundLevel = material.FoundLevel;
            EnemyType = material.EnemyType;
            AreaType = material.AreaType;
            Regions = material.Regions;
            AcuiredThroughType = material.AcuiredThroughType;

            return this;

        }
    }
}
