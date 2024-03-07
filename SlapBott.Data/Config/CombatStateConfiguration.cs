using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Services.Combat.Models;

namespace SlapBott.Data.Config
{
    public class CombatStateConfiguration : IEntityTypeConfiguration<CombatState>
    {
        public void Configure(EntityTypeBuilder<CombatState> builder)
        {
            builder
                .HasMany(x => x.Turns)
                .WithOne(x => x.CombatState)
                .HasPrincipalKey(x => new { x.CurrentTurnId, x.Id })
                .HasForeignKey(x => new { x.TurnId, x.CombatStateId });

        }
    }
}