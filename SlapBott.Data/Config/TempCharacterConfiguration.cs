using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    public class TempCharacterConfiguration : IEntityTypeConfiguration<TempCharacter>
    {
        public void Configure(EntityTypeBuilder<TempCharacter> builder)
        {
            builder
                .HasOne(c => c.Registration)
                .WithOne()
                .HasForeignKey(nameof(TempCharacter) , "DiscordID");
        }
    }
}