using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOwner : IGenericRepository<Owner>
    {
        Task<(IEnumerable<Owner> owners,int total)> OwnerWithPets (int pageIndex, int pageSize);
    }
}