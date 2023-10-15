using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class MedicalTreatmentDto
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public int Dosage { get; set; }
        public DateTime AdministrationDate { get; set; }
        public string Comment { get; set; }
    }
}