using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("Pet");
            builder.HasOne(m=>m.Owner).WithMany(o=>o.Pets).HasForeignKey(P=>P.OwnerId);
            builder.HasOne(m=>m.Breed).WithMany(o=>o.Pets).HasForeignKey(P=>P.BreedId);
            builder.Property(m=>m.Name).IsRequired().HasMaxLength(120).HasColumnName("Name");
            builder.Property(M=>M.BirthDate).HasColumnType("datetime").HasColumnName("BirthDate").IsRequired();
        }
    }
}