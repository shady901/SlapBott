using SlapBott.Data.Enums;
using SlapBott.Data.Models;

namespace SlapBott.Services.Dtos
{
    public class CharacterClassDto
    {
        public int Id { get; set; }
        public Classes Name { get; set; }

        public Dictionary<StatType, int> BaseStats { get; set; }
        public Dictionary<StatType, int> PerLevelStats { get; set; }








        public CharacterClassDto FromClass(CharacterClass pClass)
        {
            return new CharacterClassDto()
            {
                Id = pClass.Id,
                Name = pClass.Name,
                BaseStats = pClass.BaseStats,
                PerLevelStats = pClass.PerLevelStats,
            };
        }
    }
}