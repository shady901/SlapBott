using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.ItemProject.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SlapBott.ItemProject.Items
{
    public abstract class Item : IItem
    {
      

        public abstract int seed { get; set; }
        public abstract string name { get; set; }
        public abstract EquipType EquipType { get; set; }
    }
}
