using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Models
{
    public enum Races
    {
        Elf,Human,Orc
    }

    public class Race
    {
        public int Id { get; set; }
        public Races Name { get; set; }
    }
}
