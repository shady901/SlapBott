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
    public class MaterialDto : ItemDto
    {
        public ProffesionTypes[] CanBeUsedInProffesions { get; set; }





        public MaterialDto FromRecord(Material? material = null)
        {
            if (material == null)
            {
                material = new Material() { Name = string.Empty };
            }

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
        public Material ToRecord(Material? material = null)
        {
            if (material == null)
            {
                material = new Material() { Name = string.Empty };
            }

            material.CanBeUsedInProffesions = CanBeUsedInProffesions;
            material.Name = Name;
            material.Description = Description;
            material.FoundLevel = FoundLevel;
            material.EnemyType = EnemyType;
            material.AreaType = AreaType;
            material.Regions = Regions;
            material.AcuiredThroughType = AcuiredThroughType;

            return material;
        }
    }


}
