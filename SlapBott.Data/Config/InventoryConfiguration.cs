using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    internal class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Equiped)
                            .HasConversion(
                                            v => JsonConvert.SerializeObject(v),
                                            v => JsonConvert.DeserializeObject<Dictionary<EquipType, Equipment>>(v)
                                        );
            builder.HasOne(c => c.Character).WithOne(c => c.Inventory);
        }
    }
}