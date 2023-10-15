using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistency;

namespace Aplication.Repository
{
    public class PetRepository : GenericRepository<Pet>, IPet
    {
        public PetRepository(ApiDbContext context) : base(context)
        {
        }
    }
}