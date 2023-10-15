using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class MedicalTreatmentConfiguration : IEntityTypeConfiguration<MedicalTreatment>
    {
        public void Configure(EntityTypeBuilder<MedicalTreatment> builder)
        {
            builder.ToTable("MedicalTreatment");
            builder.HasOne(m=>m.Appointment).WithMany(a=>a.MedicalTreatments).HasForeignKey(m=>m.AppointmentId);
            builder.HasOne(m=>m.Medicine).WithMany(a=>a.MedicalTreatments).HasForeignKey(m=>m.MedicineId);
            builder.Property(m=>m.Dosage).HasColumnType("int").HasColumnName("Dosage").IsRequired();
            builder.Property(m=>m.AdministrationDate).HasColumnType("datetime").HasColumnName("AdministrationDate").IsRequired();
            builder.Property(m=>m.Comment).HasColumnName("comment").HasMaxLength(150).IsRequired();
        }
    }
}