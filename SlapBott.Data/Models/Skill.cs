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
        public int Id { get; set; }        
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ElementalType ElementalType { get; set; }

        public Dictionary<StatType,double> StatTypeRatio { get; set; }
        //buffs debufs



       
        
    }
}
