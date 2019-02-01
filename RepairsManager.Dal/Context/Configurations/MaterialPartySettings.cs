using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairsManager.Dal.Models;

namespace RepairsManager.Dal.Context.Configurations
{
    class MaterialPartySettings : IEntityTypeConfiguration<MaterialParty>
    {
        public void Configure(EntityTypeBuilder<MaterialParty> builder)
        {
            builder.ToTable("Material_party");

            builder.HasIndex(e => e.Number)
                .HasName("UQ__Material__78A1A19D2DCA0491")
                .IsUnique();

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Number).HasMaxLength(16);

            builder.Property(e => e.Receipt).HasColumnType("datetime");
        }
    }
}
