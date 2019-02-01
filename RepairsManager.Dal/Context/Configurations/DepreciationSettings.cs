using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairsManager.Dal.Models;

namespace RepairsManager.Dal.Context.Configurations
{
    class DepreciationSettings : IEntityTypeConfiguration<Depreciation>
    {
        public void Configure(EntityTypeBuilder<Depreciation> builder)
        {
            builder.HasIndex(e => e.Number)
                .HasName("UQ__Deprecia__78A1A19D22E79269")
                .IsUnique();

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Number)
                .IsRequired()
                .HasMaxLength(8);

            builder.Property(e => e.Organization)
                .IsRequired()
                .HasMaxLength(64)
                .HasDefaultValueSql("('ИП \"Городская аварийная служба\"')");

            builder.HasOne(d => d.Commission)
                .WithMany(p => p.Depreciation)
                .HasForeignKey(d => d.CommissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Depreciation_fk2");

            builder.HasOne(d => d.Department)
                .WithMany(p => p.Depreciation)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Depreciation_fk0");

            builder.HasOne(d => d.Material)
                .WithMany(p => p.Depreciation)
                .HasForeignKey(d => d.MaterialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Depreciation_fk3");
        }
    }
}
