using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistency;

namespace Aplication.Repository
{
    public class BreedRepository : GenericRepository<Breed>, IBreed
    {
        private readonly ApiDbContext _context;
        public BreedRepository(ApiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Breed>BreedWithHowManyPets,int Total)> GetHowManyPetsAreInTheBreed(int pageIndex, int pageSize)
        {
            var breeds =await _context.Breeds.Include(b=>b.Pets).ToListAsync();
            int total = breeds.Count;
            var Fbreeds = breeds.Skip((pageIndex -1) * pageSize).Take(pageSize);
            return (Fbreeds,total);
        }
    }
}