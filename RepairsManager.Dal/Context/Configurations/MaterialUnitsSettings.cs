using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairsManager.Dal.Models;

namespace RepairsManager.Dal.Context.Configurations
{
    class MaterialUnitsSettings : IEntityTypeConfiguration<MaterialUnits>
    {
        public void Configure(EntityTypeBuilder<MaterialUnits> builder)
        {
            builder.ToTable("Material_units");

            builder.HasIndex(e => e.Name)
                .HasName("UQ__Material__737584F6A82DA201")
                .IsUnique();

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(8);
        }
    }
}
