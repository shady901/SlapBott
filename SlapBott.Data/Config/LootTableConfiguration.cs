using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    internal class LootTableConfiguration : IEntityTypeConfiguration<LootTable>
    {
        public void Configure(EntityTypeBuilder<LootTable> builder)
        {
            builder.HasMany<LootTableItem>().WithOne().HasForeignKey(c => c.id);
        }
    }
}