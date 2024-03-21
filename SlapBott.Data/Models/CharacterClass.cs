using SlapBott.Data.Enums;

namespace SlapBott.Data.Models
{
    public class CharacterClass
    {
        public int Id { get; set; }
        public Classes Name { get; set; }

        public virtual ICollection<Character> Character { get; set; }

        public Dictionary<StatType, int> BaseStats { get; set; }
        public Dictionary<StatType, int> PerLevelStats { get; set; }

    }
}