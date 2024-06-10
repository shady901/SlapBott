using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            new Material { Id = 1, Name = "Iron Ore", Profession = "Blacksmith" },
            new Material { Id = 2, Name = "Herbs", Profession = "Alchemist" },
            new Material { Id = 3, Name = "Cloth", Profession = "Tailor" }
            ];
        }
    }
}