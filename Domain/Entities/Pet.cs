using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pet : BaseEntity
    {
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public int BreedId { get; set; }
        public Breed Breed { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}