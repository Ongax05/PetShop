using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class BreedDto
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public Species Species { get; set; }
        public string Name { get; set; }
    }
}