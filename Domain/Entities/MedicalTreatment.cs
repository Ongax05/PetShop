using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MedicalTreatment : BaseEntity
    {
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public int Dosage { get; set; }
        public DateTime AdministrationDate { get; set; }
        public string Comment { get; set; }
    }
}