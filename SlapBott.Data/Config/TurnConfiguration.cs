using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Services.Combat.Models;

namespace SlapBott.Data.Config
{
    public class TurnConfiguration : IEntityTypeConfiguration<Turn>
    {
        public void Configure(EntityTypeBuilder<Turn> builder)
        {
            builder
                .HasOne(x => x.CombatState)
                .WithMany(x => x.Turns)
                .HasPrincipalKey(x => new { x.CurrentTurnId, x.Id })
                .HasForeignKey(x => new { x.TurnId, x.CombatStateId });


            builder.HasOne(x => x.Attacker)
                    .WithMany()
                    .HasForeignKey(x => x.AttackerId);


            builder.HasMany(x => x.AttackRecords)
                .WithOne(x => x.Turn)
                .HasForeignKey(x => x.TurnId);

             builder.HasKey(x => x.Id);
                
        }
    }
}