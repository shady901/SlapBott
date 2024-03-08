using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    internal class RaidBossConfiguration : IEntityTypeConfiguration<RaidBoss>
    {
        public void Configure(EntityTypeBuilder<RaidBoss> builder)
        {
          
        }
    }
}