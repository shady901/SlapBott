using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Data.Models;
using System.Reflection.Emit;

namespace SlapBott.Data.Config
{
    public class EnemyConfiguration : IEntityTypeConfiguration<Enemy>
    {
        public void Configure(EntityTypeBuilder<Enemy> builder)
        {
            builder.ToTable("Enemies");
            builder
             .HasOne(e => e.Region)
             .WithOne()
             .HasForeignKey<Enemy>(e => e.RegionId);
        }
    }
}