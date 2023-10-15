using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public int VeterinarianId { get; set; }
        public Veterinarian Veterinarian { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public ICollection<MedicalTreatment> MedicalTreatments { get; set; }
    }
}