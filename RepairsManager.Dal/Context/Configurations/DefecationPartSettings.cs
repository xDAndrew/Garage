using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairsManager.Dal.Models;

namespace RepairsManager.Dal.Context.Configurations
{
    class DefecationPartSettings : IEntityTypeConfiguration<DefecationPart>
    {
        public void Configure(EntityTypeBuilder<DefecationPart> builder)
        {
            builder.ToTable("Defecation_part");

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Scope)
                .IsRequired()
                .HasMaxLength(16)
                .HasDefaultValueSql("('Заменено')");

            builder.HasOne(d => d.Material)
                .WithMany(p => p.DefecationPart)
                .HasForeignKey(d => d.MaterialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Defecation_part_fk0");
        }
    }
}
