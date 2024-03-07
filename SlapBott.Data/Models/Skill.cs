using Microsoft.EntityFrameworkCore;
using SlapBott.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Models
{
    public class Skill
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public ElementalType ElementalType { get; set; }

        public Dictionary<StatType,double> StatTypeRatio { get; set; }
        //buffs debufs



        public StatType GetSkillStatTypeByElement()
        {
            switch (ElementalType)
            {
                case ElementalType.Fire:
                    return StatType.ElementalDamage;
                case ElementalType.Frost:
                    return StatType.ElementalDamage;
                case ElementalType.Lightning:
                    return StatType.ElementalDamage;
                case ElementalType.Physical:
                    return StatType.PhysicalDamage;
                case ElementalType.Chaos:
                    return StatType.ChaosDamage;
                default:
                    return StatType.none;
            }

        }
        
    }
}
