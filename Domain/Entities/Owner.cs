using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Owner : BaseEntity
    {
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}