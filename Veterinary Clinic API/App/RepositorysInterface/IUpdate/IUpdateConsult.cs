﻿using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.RepositorysInterface.IUpdate
{
    public interface IUpdateConsult
    {
        void Update(Guid id, Consultation consult);
    }
}
