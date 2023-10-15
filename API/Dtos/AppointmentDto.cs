using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public int VeterinarianId { get; set; }
        public Veterinarian Veterinarian { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
    }
}