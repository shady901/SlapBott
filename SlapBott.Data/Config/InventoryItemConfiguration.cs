using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    public class InventoryItemConfiguration : IEntityTypeConfiguration<InventoryItem>
    {
        public void Configure(EntityTypeBuilder<InventoryItem> builder)
        {
           builder.HasOne(c=>c.Inventory)
                .WithOne()
                .HasForeignKey<InventoryItem>(c => c.InventoryId);

            builder.HasOne(z => z.Equipment)
                .WithOne()
                .HasForeignKey<InventoryItem>(z=>z.EquipmentId);

        }
    }
}