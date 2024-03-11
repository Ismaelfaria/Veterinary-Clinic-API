using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.ServicesInterface.ICreateService
{
    public interface ICreateConsult
    {
        Consultation Create(Consultation consultation);
    }
}
