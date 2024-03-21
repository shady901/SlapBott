using SlapBott.Data.Enums;
using SlapBott.Data.Models;

namespace SlapBott.Services.Dtos
{
    public class RaceDto
    {
        public int Id { get; set; }
        public Races Name { get; set; }

        public Dictionary<StatType, int> BaseStats { get; set; }
        public Dictionary<StatType, int> PerLevelStats { get; set; }








        public RaceDto FromRace(Race r)
        {
            return new RaceDto()
            {
                Id = r.Id,
                Name = r.Name,
                BaseStats = r.BaseStats,
                PerLevelStats = r.PerLevelStats,
            };
        }
    }
}