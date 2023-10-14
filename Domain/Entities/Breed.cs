using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Breed : BaseEntity
    {
        public int SpeciesId { get; set; }
        public Species Species { get; set; }
        public string Name { get; set; }
        public ICollection<Pet> Pets { get; set; }
        
    }
}