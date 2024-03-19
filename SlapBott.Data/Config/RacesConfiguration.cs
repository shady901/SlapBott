using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    public class RacesConfiguration : IEntityTypeConfiguration<Race>
    {
        public void Configure(EntityTypeBuilder<Race> builder)
        {

            builder.HasKey(x => x.Name);
        

            builder.Property(x => x.PerLevelStats)
                        .HasConversion(
                                        v => JsonConvert.SerializeObject(v),
                                        v => JsonConvert.DeserializeObject<Dictionary<StatType, int>>(v)
                                    );
            builder.Property(x => x.BaseStats)
                        .HasConversion(
                                        v => JsonConvert.SerializeObject(v),
                                        v => JsonConvert.DeserializeObject<Dictionary<StatType, int>>(v)
                                    );
            builder.HasData(SeedRaces());

        }
        public Race[] SeedRaces()
        {
            List<Race> myRaces = new();
            myRaces.Add(new Race()
            {
               Id = (int)Races.Elf,
               Name = Races.Elf,
               BaseStats =
               new Dictionary<StatType, int>
               {
                    { StatType.DodgeChance, 5}
               },
               PerLevelStats = new Dictionary<StatType, int>
               {
                    { StatType.DodgeChance, 5}
               }
            });




            return myRaces.ToArray();
        }
    }
}