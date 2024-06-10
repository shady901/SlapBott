using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}