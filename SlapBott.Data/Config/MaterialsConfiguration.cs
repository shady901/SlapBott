using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    internal class MaterialsConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder
            .ToTable("Materials")
            .HasBaseType<Item>()
            .HasData(MaterialsSeeder());

        }



        public Material[] MaterialsSeeder()
        {
           
            return [ 
            new Material { Id = 1, Name = "Iron Ore",AcuiredThroughType = GatheringType.Mining,FoundLevel=2,AreaType = AreaType.Cave, CanBeUsedInProffesions = [ProffesionTypes.BlackSmith],EnemyType = EnemyTypes.None,Regions = Regions.Plains,Description = "An Ore Found in Caves that can be used to Craft Iron Gear at a BlackSmith" },
             ];
        }
    }
}