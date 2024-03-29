﻿using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.RepositorysInterface.IGet
{
    public interface IGetDoctorR
    {
        IEnumerable<Doctor> FindAll();
        Doctor FindByUserName(string name);
        Doctor FindByRegister(int doctorRegister);
    }
}
