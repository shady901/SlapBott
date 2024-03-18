using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Data.Models;
using System.Reflection.Emit;


namespace SlapBott.Data.Config
{
    public class PlayCharacterConfiguration : IEntityTypeConfiguration<PlayerCharacter>
    {
        public void Configure(EntityTypeBuilder<PlayerCharacter> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(c => c.Registration)
                
                .WithMany(r => r.PlayerCharacters)
                .HasForeignKey(r => r.RegistrationId);

            builder.HasOne(c => c.Character).WithOne();

        }

    }
}