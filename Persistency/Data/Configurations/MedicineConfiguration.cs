using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.ToTable("Medicine");
            builder.HasOne(m=>m.Supplier).WithMany(m=>m.Medicines).HasForeignKey(m=>m.SupplierId);
            builder.Property(m=>m.Name).IsRequired().HasMaxLength(110).HasColumnName("Name");
            builder.Property(m=>m.Stock).HasColumnName("stock").HasColumnType("int").IsRequired();
            builder.Property(m=>m.Price).HasColumnName("Price").HasColumnType("double   ").IsRequired();
            builder.Property(m=>m.Laboratory).IsRequired().HasMaxLength(110).HasColumnName("Laboratory");
        }
    }
}