using MediatR;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.Services.Implmentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
    public class SkillDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ElementalType ElementalType { get; set; }
        public Dictionary<StatType, double>? StatTypeRatio { get; set; }
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
                    return StatType.PhysicalPower;
                case ElementalType.Chaos:
                    return StatType.ChaosDamage;
                default:
                    return StatType.none;
            }

        }


        public SkillDto FromSkill(Skill mySkill)
        {
            return new SkillDto()
            {
                Id = mySkill.Id,
                Name = mySkill.Name,
                Description = mySkill.Description,
                ElementalType = mySkill.ElementalType,
                StatTypeRatio = mySkill.StatTypeRatio,
            };
        }
      
    }
}
