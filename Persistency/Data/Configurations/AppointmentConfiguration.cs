using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Data.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointment");
            builder.HasOne(a=>a.Pet).WithMany(p=>p.Appointments).HasForeignKey(a=>a.PetId);
            builder.HasOne(a=>a.Veterinarian).WithMany(p=>p.Appointments).HasForeignKey(a=>a.VeterinarianId);
            builder.Property(a=>a.Date).HasColumnName("Date").HasColumnType("datetime").IsRequired();
            builder.Property(a=>a.Reason).HasColumnName("Reason").HasMaxLength(500).IsRequired();
        }
    }
}