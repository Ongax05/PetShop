using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistency;

namespace Aplication.Repository
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointment
    {
        private readonly ApiDbContext _context;

        public AppointmentRepository(ApiDbContext context) : base (context)
        {
            _context = context;
        }
    }
}