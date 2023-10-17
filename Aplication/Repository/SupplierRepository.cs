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
    public class SupplierRepository : GenericRepository<Supplier>, ISupplier
    {
        private readonly ApiDbContext _context;
        public SupplierRepository(ApiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Supplier> suppliers, int totals)> GetWhoShells(int pageIndex, int pageSize,string medicineName)
        {
            var registers = await _context.Suppliers.Where (s=>s.Medicines.Any(m=>m.Name == medicineName)).ToListAsync();
            var Fregisters = registers.Skip((pageIndex -1) * pageSize).Take(pageSize);
            var a = registers.Count;
            return (Fregisters,a);
        }
    }
}