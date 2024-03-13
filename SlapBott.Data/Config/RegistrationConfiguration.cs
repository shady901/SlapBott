using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.ToTable("Users");

            builder.Property(x=>x.UserName).IsRequired();
            builder.Property(x => x.DiscordId).IsRequired();

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Character)
                .WithMany().HasForeignKey(x => x.ActiveCharacterId);

            builder.HasOne(x => x.TempCharacter)
                .WithOne().HasForeignKey(nameof(TempCharacter), "TemporaryCharacterId");



            builder.HasMany(x => x.PlayerCharacters)
                    .WithOne(x => x.Registration).HasForeignKey(x=>x.DiscordID);

        }
    }
}