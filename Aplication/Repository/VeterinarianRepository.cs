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
    public class VeterinarianRepository : GenericRepository<Veterinarian>, IVeterinarian
    {
        private readonly ApiDbContext _context;
        public VeterinarianRepository(ApiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Veterinarian> registers, int totalRegisters)> GetVeterinariansBySpeciality(int pageIndex, int pageSize,string speciality)
        {
            var registers = await _context.Veterinarians.Where(V=>V.Speciality.Equals(speciality)).Skip((pageIndex -1) * pageSize).Take(pageSize).ToListAsync();
            int totalRegisters = registers.Count;
            return (registers, totalRegisters);
        }
    }
}