using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class PetDto
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int BreedId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}