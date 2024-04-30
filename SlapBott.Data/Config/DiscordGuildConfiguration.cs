using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    internal class DiscordGuildConfiguration : IEntityTypeConfiguration<DiscordGuild>
    {
        public void Configure(EntityTypeBuilder<DiscordGuild> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ConfiguredChannels)
                          .HasConversion(
                                          v => JsonConvert.SerializeObject(v),
                                          v => JsonConvert.DeserializeObject<Dictionary<Regions, ulong>>(v)
                                      );
        }
    }
}