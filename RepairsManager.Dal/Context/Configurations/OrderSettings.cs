using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairsManager.Dal.Models;

namespace RepairsManager.Dal.Context.Configurations
{
    class OrderSettings : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.CreateOn).HasColumnType("datetime");

            builder.HasOne(d => d.Fault)
                .WithMany(p => p.Order)
                .HasForeignKey(d => d.FaultId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_fk2");

            builder.HasOne(d => d.Status)
                .WithMany(p => p.Order)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_fk1");

            builder.HasOne(d => d.Vehicle)
                .WithMany(p => p.Order)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_fk0");
        }
    }
}
