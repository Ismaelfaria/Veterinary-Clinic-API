using AutoMapper;
using Veterinary_Clinic_API.App.Mapping.Models.InputModels;
using Veterinary_Clinic_API.App.Mapping.Models.ViewModels;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.Mapping.Profilers
{
    public class ConsultProfile : Profile
    {
        public ConsultProfile()
        {
            CreateMap<InputConsultation, Consultation>().ReverseMap();
            CreateMap<ViewConsultation, Consultation>().ReverseMap();
        }
    }
}
