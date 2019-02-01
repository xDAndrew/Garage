using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairsManager.Dal.Models;

namespace RepairsManager.Dal.Context.Configurations
{
    class DefecationResponsibleSettings : IEntityTypeConfiguration<DefecationResponsible>
    {
        public void Configure(EntityTypeBuilder<DefecationResponsible> builder)
        {
            builder.ToTable("Defecation_responsible");

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.DefecationId).HasColumnName("defecationId");

            builder.Property(e => e.EmployeeId).HasColumnName("employeeId");

            builder.HasOne(d => d.Defecation)
                .WithMany(p => p.DefecationResponsible)
                .HasForeignKey(d => d.DefecationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Defecation_responsible_fk0");
        }
    }
}
