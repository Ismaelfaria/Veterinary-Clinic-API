﻿using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.ServicesInterface.IGetService
{
    public interface IGetAdminS
    {
        Admin FindByUserName(string name);
    }
}
