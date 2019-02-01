using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairsManager.Dal.Models;

namespace RepairsManager.Dal.Context.Configurations
{
    class VehicleMarkSettings : IEntityTypeConfiguration<VehicleMark>
    {
        public void Configure(EntityTypeBuilder<VehicleMark> builder)
        {
            builder.ToTable("Vehicle_mark");

            builder.HasIndex(e => e.Name)
                .HasName("UQ__Vehicle___737584F62C8CFEDB")
                .IsUnique();

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(64);
        }
    }
}
