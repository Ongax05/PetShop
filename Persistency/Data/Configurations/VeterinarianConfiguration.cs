using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class VeterinarianConfiguration : IEntityTypeConfiguration<Veterinarian>
    {
        public void Configure(EntityTypeBuilder<Veterinarian> builder)
        {
            builder.ToTable("Veterinarian");
            builder.Property(m=>m.Name).IsRequired().HasMaxLength(150).HasColumnName("Name");
            builder.Property(m=>m.Email).IsRequired().HasMaxLength(150).HasColumnName("Email");
            builder.Property(m=>m.Telephone).IsRequired().HasMaxLength(150).HasColumnName("Telephone");
            builder.Property(m=>m.Speciality).IsRequired().HasMaxLength(150).HasColumnName("Speciality");
        }
    }
}