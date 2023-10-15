using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Supplier");
            builder.Property(M=>M.Name).HasColumnName("Name").IsRequired().HasMaxLength(150);
            builder.Property(M=>M.Address).HasColumnName("Address").IsRequired().HasMaxLength(200);
            builder.Property(M=>M.Telephone).HasColumnName("Telephone").IsRequired().HasMaxLength(200);
        }
    }
}