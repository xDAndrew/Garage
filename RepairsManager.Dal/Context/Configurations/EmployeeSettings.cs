using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairsManager.Dal.Models;

namespace RepairsManager.Dal.Context.Configurations
{
    class EmployeeSettings : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(e => e.MiddleName)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder.HasOne(d => d.Department)
                .WithMany(p => p.Employee)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employee_fk1");

            builder.HasOne(d => d.Position)
                .WithMany(p => p.Employee)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employee_fk0");
        }
    }
}
