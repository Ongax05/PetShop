using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owner");
            builder.Property(o=>o.Name).IsRequired().HasMaxLength(70).HasColumnName("Name");
            builder.Property(o=>o.Telephone).IsRequired().HasMaxLength(50).HasColumnName("Telephone");
            builder.Property(o=>o.Email).IsRequired().HasMaxLength(150).HasColumnName("Email");
        }
    }
}