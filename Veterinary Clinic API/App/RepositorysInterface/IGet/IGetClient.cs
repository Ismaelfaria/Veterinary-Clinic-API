﻿using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.RepositorysInterface.IGet
{
    public interface IGetClient
    {
        IEnumerable<Client> FindAll();
        Client FindByUserName();
    }
}
