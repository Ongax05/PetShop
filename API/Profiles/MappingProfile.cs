using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile (){
            CreateMap<Appointment,AppointmentDto>().ReverseMap();
            CreateMap<Breed,BreedDto>().ReverseMap();
            CreateMap<MedicalTreatment,MedicalTreatmentDto>().ReverseMap();
            CreateMap<Medicine,MedicineDto>().ReverseMap();
            CreateMap<Owner,OwnerDto>().ReverseMap();
            CreateMap<Owner,OwnerWithPetsDto>().ReverseMap();
            CreateMap<Pet,PetDto>().ReverseMap();
            CreateMap<Pet,PetWithOwnerDto>().ReverseMap();
            CreateMap<PurchasedMedicine,PurchasedMedicineDto>().ReverseMap();
            CreateMap<SoldMedicine,SoldMedicineDto>().ReverseMap();
            CreateMap<Species,SpeciesDto>().ReverseMap();
            CreateMap<Supplier,SupplierDto>().ReverseMap();
            CreateMap<Veterinarian,VeterinarianDto>().ReverseMap();
        }
    }
}