using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    internal class LootTableItemConfiguration : IEntityTypeConfiguration<LootTableItem>
    {
        public void Configure(EntityTypeBuilder<LootTableItem> builder)
        {
          //  builder.HasOne(c => c.BaseItem).WithMany().HasForeignKey(c=>c.ItemId);
        }
    }
}