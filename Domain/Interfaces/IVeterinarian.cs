using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IVeterinarian : IGenericRepository<Veterinarian>
    {
        Task<(IEnumerable<Veterinarian> registers, int totalRegisters)> GetVeterinariansBySpeciality(int pageIndex, int pageSize,string speciality);
    }
}