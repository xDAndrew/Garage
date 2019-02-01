using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairsManager.Dal.Models;

namespace RepairsManager.Dal.Context.Configurations
{
    class VehicleSettings : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasIndex(e => e.RegNumber)
                .HasName("UQ__Vehicle__18B201F636734836")
                .IsUnique();

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.RegNumber)
                .IsRequired()
                .HasColumnName("Reg_number")
                .HasMaxLength(16);

            builder.HasOne(d => d.Driver)
                .WithMany(p => p.Vehicle)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Vehicle_fk1");

            builder.HasOne(d => d.VehicleModel)
                .WithMany(p => p.Vehicle)
                .HasForeignKey(d => d.VehicleModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Vehicle_fk0");
        }
    }
}
