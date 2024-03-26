using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.ItemProject.Items
{
    public class Weapon : Item
    {
        public bool TwoHanded { get; set; } 
        public int BaseDamage { get; set; }
        public Weapon(Random random, int itemLevel) : base(random, itemLevel)
        {
            
        }

      
    }
}
