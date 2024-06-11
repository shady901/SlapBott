using SlapBott.ItemProject.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
    public class DisplayDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }




        public static DisplayDto FromTarget(Target target)
        {
            return new() { Description = target.Description, Name= target.Name };
        
        }
        public static DisplayDto FromItem(ItemDto item) 
        {
            return new() { Description = item.Description, Name = item.Name };
        }
    }
}
