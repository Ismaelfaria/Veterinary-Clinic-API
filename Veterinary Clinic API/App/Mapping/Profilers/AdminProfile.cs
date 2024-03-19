﻿using AutoMapper;
using Veterinary_Clinic_API.App.Mapping.Models.InputModels;
using Veterinary_Clinic_API.App.Mapping.Models.ViewModels;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.Mapping.Profilers
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<InputAdmin, Admin>().ReverseMap();
            CreateMap<ViewAdmin, Admin>().ReverseMap();
        }
    }
}
