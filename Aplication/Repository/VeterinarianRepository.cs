using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistency;

namespace Aplication.Repository
{
    public class VeterinarianRepository : GenericRepository<Veterinarian>, IVeterinarian
    {
        public VeterinarianRepository(ApiDbContext context) : base(context)
        {
        }
    }
}