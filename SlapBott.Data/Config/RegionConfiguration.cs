using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
          
            builder.HasData(SeedingRegions());
        }
        private Region[] SeedingRegions()
        {
            List<Region> regions = new List<Region>()
            {
                { new Region() {Id = 1,RegionName=Regions.Searing_Scale_Peaks,isBossPending = false} },
                { new Region() {Id = 2,RegionName=Regions.Plains,isBossPending = false} },
                 { new Region() {Id = 3,RegionName=Regions.Chaotic_Rift,isBossPending = false} },
                  { new Region() {Id = 4,RegionName=Regions.Whispering_Woods,isBossPending = false} },
                   { new Region() {Id = 5,RegionName=Regions.Blizzard_Highlands,isBossPending = false} },
                    { new Region() {Id = 6,RegionName=Regions.BadLands,isBossPending = false} },

            };

            return regions.ToArray();
        }
    }
}