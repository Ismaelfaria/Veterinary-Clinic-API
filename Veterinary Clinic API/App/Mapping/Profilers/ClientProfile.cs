using AutoMapper;
using Veterinary_Clinic_API.App.Mapping.Models.InputModels;
using Veterinary_Clinic_API.App.Mapping.Models.ViewModels;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.Mapping.Profilers
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<InputClient, Client>().ReverseMap();
            CreateMap<ViewClient, Client>().ReverseMap();
        }
    }
}
