using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class PurchasedMedicineConfiguration : IEntityTypeConfiguration<PurchasedMedicine>
    {
        public void Configure(EntityTypeBuilder<PurchasedMedicine> builder)
        {
            builder.HasOne(P=>P.Supplier).WithMany(p=>p.PurchasedMedicines).HasForeignKey(p=>p.SupplierId);
            builder.HasOne(P=>P.Medicine).WithMany(p=>p.PurchasedMedicines).HasForeignKey(p=>p.MedicineId);
            builder.Property(P=>P.Amount).HasColumnType("int").IsRequired().HasColumnName("Amount");
            builder.Property(P=>P.Price).HasColumnType("double").IsRequired().HasColumnName("Price");
            builder.Property(P=>P.PurchaseDate).HasColumnType("datetime").IsRequired().HasColumnName("PurchaseDate");
        }
    }
}