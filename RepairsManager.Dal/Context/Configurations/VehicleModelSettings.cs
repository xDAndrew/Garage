using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairsManager.Dal.Models;

namespace RepairsManager.Dal.Context.Configurations
{
    class VehicleModelSettings : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.ToTable("Vehicle_model");

            builder.HasIndex(e => e.Name)
                .HasName("UQ__Vehicle___737584F6D60374B5")
                .IsUnique();

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(64);

            builder.HasOne(d => d.VehicleMark)
                .WithMany(p => p.VehicleModel)
                .HasForeignKey(d => d.VehicleMarkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Vehicle_model_fk0");
        }
    }
}
