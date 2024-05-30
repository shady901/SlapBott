using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    public class PlayerStatsConfiguration : IEntityTypeConfiguration<Stats>
    {
        public void Configure(EntityTypeBuilder<Stats> builder)
        {
            //builder
            //    .HasOne(s => s.Character)
            //    .WithOne(c => c.Stats)
            //    .HasForeignKey<Character>(s => s.StatsId);

            builder.Property(x => x.stats)
                           .HasConversion(
                                           v => JsonConvert.SerializeObject(v),
                                           v => JsonConvert.DeserializeObject<Dictionary<StatType, int>>(v)
                                       );

        }


    }
}