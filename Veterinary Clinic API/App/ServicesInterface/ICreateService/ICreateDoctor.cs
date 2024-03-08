using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.ServicesInterface.ICreateService
{
    public interface ICreateDoctor
    {
        Doctor Create(Doctor doctor);
    }
}
