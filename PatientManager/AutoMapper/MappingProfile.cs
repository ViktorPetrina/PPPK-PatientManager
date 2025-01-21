using AutoMapper;
using DataLayer.Models;
using PatientManager.ViewModels;

namespace PatientManager.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Patient, PatientVM>().ReverseMap();
        }
    }
}
