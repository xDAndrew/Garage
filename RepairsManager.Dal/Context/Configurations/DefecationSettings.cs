using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairsManager.Dal.Models;

namespace RepairsManager.Dal.Context.Configurations
{
    class DefecationSettings : IEntityTypeConfiguration<Defecation>
    {
        public void Configure(EntityTypeBuilder<Defecation> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.CreateOn).HasColumnType("datetime");

            builder.HasOne(d => d.Approved)
                .WithMany(p => p.Defecation)
                .HasForeignKey(d => d.ApprovedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Defecation_fk2");

            builder.HasOne(d => d.Part)
                .WithMany(p => p.Defecation)
                .HasForeignKey(d => d.PartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Defecation_fk1");

            builder.HasOne(d => d.Vehicle)
                .WithMany(p => p.Defecation)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Defecation_fk0");
        }
    }
}
