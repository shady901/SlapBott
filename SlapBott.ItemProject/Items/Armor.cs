using SlapBott.Data.Enums;
using SlapBott.ItemProject.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.ItemProject.Items
{
    public class Armor : Item
    {
        public Armor(Random random, int itemLevel, EquipType equipType) : base(random, itemLevel, equipType)
        {
        }
    }
}
