using Aplication.Repository;
using Domain.Interfaces;
using Persistency;
namespace Aplication.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiDbContext _context;
    private IRolRepository _roles;
    private IUserRepository _users;
    public UnitOfWork(ApiDbContext context)
    {
        _context = context;
    }
    public IRolRepository Roles
    {
        get
        {
            _roles ??= new RolRepository(_context);
            return _roles;
        }
    }

    public IUserRepository Users
    {
        get
        {
            _users ??= new UserRepository(_context);
            return _users;
        }
    }
        private IVeterinarian _Veterinarian;
    public IVeterinarian Veterinarian
    {
        get { 
            _Veterinarian ??= new VeterinarianRepository(_context);
                return _Veterinarian;
            }
    }
    private ISupplier _Supplier;
    public ISupplier Supplier
    {
        get { 
            _Supplier ??= new SupplierRepository(_context);
                return _Supplier;
            }
    }
    private ISpecies _Species;
    public ISpecies Species
    {
        get { 
            _Species ??= new SpeciesRepository(_context);
                return _Species;
            }
    }
    private ISoldMedicine _SoldMedicine;
    public ISoldMedicine SoldMedicine
    {
        get { 
            _SoldMedicine ??= new SoldMedicineRepository(_context);
                return _SoldMedicine;
            }
    }
    private IPurchasedMedicine _PurchasedMedicine;
    public IPurchasedMedicine PurchasedMedicine
    {
        get { 
            _PurchasedMedicine ??= new PurchasedMedicineRepository(_context);
                return _PurchasedMedicine;
            }
    }
    private IPet _Pet;
    public IPet Pet
    {
        get { 
            _Pet ??= new PetRepository(_context);
                return _Pet;
            }
    }
    private IOwner _Owner;
    public IOwner Owner
    {
        get { 
            _Owner ??= new OwnerRepository(_context);
                return _Owner;
            }
    }
    private IMedicine _Medicine;
    public IMedicine Medicine
    {
        get { 
            _Medicine ??= new MedicineRepository(_context);
                return _Medicine;
            }
    }
    private IMedicalTreatment _MedicalTreatment;
    public IMedicalTreatment MedicalTreatment
    {
        get { 
            _MedicalTreatment ??= new MedicalTreatmentRepository(_context);
                return _MedicalTreatment;
            }
    }
    private IAppointment _Appointment;
    public IAppointment Appointment
    {
        get { 
            _Appointment ??= new AppointmentRepository(_context);
                return _Appointment;
            }
    }
    private IBreed _Breed;
    public IBreed Breed
    {
        get { 
            _Breed ??= new BreedRepository(_context);
                return _Breed;
            }
    } 
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
