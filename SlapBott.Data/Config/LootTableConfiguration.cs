using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Data.Models;
using System.Reflection.Emit;

namespace SlapBott.Data.Config
{
    internal class LootTableConfiguration : IEntityTypeConfiguration<LootTable>
    {
        public void Configure(EntityTypeBuilder<LootTable> builder)
        {
           builder
           .HasMany(lt => lt.LootTableItems)
           .WithOne(lti => lti.LootTable)
           .HasForeignKey(lti => lti.LootTableId);
        }
    }
}