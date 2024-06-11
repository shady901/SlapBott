using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    public class EnemyConfiguration : IEntityTypeConfiguration<Enemy>
    {
        public void Configure(EntityTypeBuilder<Enemy> builder)
        {
            builder.ToTable("Enemies");

            builder.HasMany(e => e.LootTables)
            .WithOne(lt => lt.Enemy)
            .HasForeignKey(lt => lt.EnemyId);


        }
    }
}