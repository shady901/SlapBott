using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.ToTable("Registration");
            builder.HasKey(x => x.Id);


            builder.Property(x=>x.UserName).IsRequired();
            builder.Property(x => x.DiscordId).IsRequired();


            builder.HasOne(x => x.Character)
                .WithMany().HasForeignKey(x => x.ActiveCharacterId);


        }
    }
}