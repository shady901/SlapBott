using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Data.Models;
using System.Reflection.Emit;

namespace SlapBott.Data.Config
{
    internal class ItemsConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
          builder
                .ToTable("Items")
                .HasKey(i => i.Id);
        }
    }
}