using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.ToTable("Breed");
            builder.HasOne(b=>b.Species).WithMany(s=>s.Breeds).HasForeignKey(b=>b.SpeciesId);
            builder.Property(b=>b.Name).IsRequired().HasMaxLength(70).HasColumnName("Name");
        }
    }
}