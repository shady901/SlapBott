using SlapBott.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services
{
    public static class ElementalAndStatTypeHelper
    {
        public static StatType ReturnStatTypeByElementalType(ElementalType elementalType)
        {
            switch (elementalType)
            {
              
                case ElementalType.Fire:
                    return StatType.FireResistance;
                   
                case ElementalType.Frost:
                   return StatType.FrostResistance;
                case ElementalType.Lightning:
                   return StatType.LightningResistance;
                case ElementalType.Physical:
                    return StatType.PhysicalResistance;
                case ElementalType.Chaos:
                    return StatType.ChaosResistance;
                default:
                    return StatType.none;
            }


        }

    }
}
