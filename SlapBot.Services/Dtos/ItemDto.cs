using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
    public class ItemDto
    {
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;

        public int FoundLevel { get; set; }
        public EnemyTypes? EnemyType { get; set; }
        public AreaType? AreaType { get; set; }
        public Regions? Regions { get; set; }
        public ProffessionType? AcuiredThroughType { get; set; }


        
    }
}
