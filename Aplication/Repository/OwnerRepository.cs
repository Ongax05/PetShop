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
    public class OwnerRepository : GenericRepository<Owner>, IOwner
    {
        private readonly ApiDbContext _context;
        public OwnerRepository(ApiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Owner> owners, int total)> OwnerWithPets(int pageIndex, int pageSize)
        {
            var registers = await _context.Owners.Include(o=>o.Pets).ToListAsync();
            var Fregisters = registers.Skip((pageIndex -1) * pageSize).Take(pageSize).ToList();
            int totalRegisters = registers.Count;
            return (Fregisters, totalRegisters);
            throw new NotImplementedException();
        }
    }
}