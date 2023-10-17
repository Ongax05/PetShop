using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ISupplier : IGenericRepository<Supplier>
    {
        Task<(IEnumerable<Supplier> suppliers, int totals)> GetWhoShells (int pageIndex, int pageSize,string medicineName);
    }
}