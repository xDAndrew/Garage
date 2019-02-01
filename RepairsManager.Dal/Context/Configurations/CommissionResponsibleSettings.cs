using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairsManager.Dal.Models;

namespace RepairsManager.Dal.Context.Configurations
{
    class CommissionResponsibleSettings : IEntityTypeConfiguration<CommissionResponsible>
    {
        public void Configure(EntityTypeBuilder<CommissionResponsible> builder)
        {
            builder.ToTable("Commission_responsible");

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasOne(d => d.Commission)
                .WithMany(p => p.CommissionResponsible)
                .HasForeignKey(d => d.CommissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Commission_responsible_fk0");

            builder.HasOne(d => d.Employee)
                .WithMany(p => p.CommissionResponsible)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Commission_responsible_fk1");
        }
    }
}
