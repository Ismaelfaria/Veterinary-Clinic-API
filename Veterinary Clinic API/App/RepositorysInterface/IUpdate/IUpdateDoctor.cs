﻿using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.RepositorysInterface.IUpdate
{
    public interface IUpdateDoctor
    {
        Doctor Update(string firstName, string lastName, int contactNumber, int cpf, int doctorRegistration);
    }
}