using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Data.Models;
using System.Reflection.Emit;

namespace SlapBott.Data.Config
{
    internal class LootTableItemConfiguration : IEntityTypeConfiguration<LootTableItem>
    {
        public void Configure(EntityTypeBuilder<LootTableItem> builder)
        {
            builder
             .Property(lti => lti.ItemType)
            .IsRequired();

           builder.HasOne<Material>()
                .WithMany()
                .HasForeignKey(lti => lti.ItemId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<Consumable>()
                .WithMany()
                .HasForeignKey(lti => lti.ItemId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}