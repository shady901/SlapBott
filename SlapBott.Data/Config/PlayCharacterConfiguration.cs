using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Data.Models;


namespace SlapBott.Data.Config
{
    public class PlayCharacterConfiguration : IEntityTypeConfiguration<PlayerCharacter>
    {
        public void Configure(EntityTypeBuilder<PlayerCharacter> builder)
        {
            builder
                .HasOne(c => c.Registration)
                .WithMany(r => r.PlayerCharacters)
                .HasForeignKey(r => r.DiscordID);

        //    builder.ToTable<PlayerCharacter>("Character");


        }

    }
}