using SlapBott.Data.Enums;
using SlapBott.ItemProject.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.ItemProject.Items
{
    public class Weapon : Item
    {

        public int Damage { get; set; }
        public WeaponType WeaponType { get; set; }
        public int Accuracy { get; set; }
        public double AttackSpeed { get; set; }
        public Handed Handed { get; set; }

        public Weapon(Random random, int itemLevel) : base(random, itemLevel)
        {
            
        }

      
    }
}
