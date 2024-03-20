using SlapBott.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Models
{
    public class Race
    {
        public int Id { get; set; }
        public Races Name { get; set; }
      
        public virtual ICollection<Character> Character { get; set; }

        public Dictionary<StatType, int> BaseStats { get; set; }
        public Dictionary<StatType, int> PerLevelStats { get; set; }

    }
}
