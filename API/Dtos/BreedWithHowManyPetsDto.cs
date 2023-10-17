using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class BreedWithHowManyPetsDto
    {
        public BreedDto Breed { get; set; }
        public IEnumerable<int> PetIds { get; set; }
        public int Total { get; set; }
    }
}