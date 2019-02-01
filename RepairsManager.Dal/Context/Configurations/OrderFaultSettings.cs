using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairsManager.Dal.Models;

namespace RepairsManager.Dal.Context.Configurations
{
    class OrderFaultSettings : IEntityTypeConfiguration<OrderFault>
    {
        public void Configure(EntityTypeBuilder<OrderFault> builder)
        {
            builder.ToTable("Order_fault");

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(512);
        }
    }
}
