using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class SoldMedicineConfiguration : IEntityTypeConfiguration<SoldMedicine>
    {
        public void Configure(EntityTypeBuilder<SoldMedicine> builder)
        {
            builder.ToTable("SoldMedicine");
            builder.HasOne(o=>o.Medicine).WithMany(p=>p.SoldMedicines).HasForeignKey(p=>p.MedicineId);
            builder.Property(m=>m.Amount).IsRequired().HasColumnType("int").HasColumnName("Amount");
            builder.Property(m=>m.Price).IsRequired().HasColumnType("double").HasColumnName("Price");
            builder.Property(m=>m.SoldDate).IsRequired().HasColumnType("datetime").HasColumnName("SoldDate");
        }
    }
}