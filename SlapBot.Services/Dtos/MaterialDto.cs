using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.ItemProject.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Dtos
{
    public class MaterialDto:ItemDto
    {
        public ProffessionType[] CanBeUsedInProffesions { get; set; }





        public MaterialDto FromMaterial(Material material)  
        {
          
            CanBeUsedInProffesions = material.CanBeUsedInProffesions;
            Name = material.Name;
            Description = material.Description;
            FoundLevel = material.FoundLevel;
            EnemyType = material.EnemyType;
            AreaType = material.AreaType;
            Regions = material.Regions;
            AcuiredThroughType = material.AcuiredThroughType;

            return this;         
        
        }
    }


}
