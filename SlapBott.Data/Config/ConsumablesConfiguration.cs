﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlapBott.Data.Models;

namespace SlapBott.Data.Config
{
    internal class ConsumablesConfiguration : IEntityTypeConfiguration<Consumable>
    {
        public void Configure(EntityTypeBuilder<Consumable> builder)
        {
          builder
                .ToTable("Consumables")
                .HasBaseType<Item>();
        }
    }
}