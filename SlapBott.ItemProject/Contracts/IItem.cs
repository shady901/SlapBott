using SlapBott.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.ItemProject.Contracts
{
    public interface IItem
    {
        int seed { get; set; }
        string name { get; set; }
        EquipType EquipType { get; set; }

    }
}
