using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.ServicesInterface.IUpdateService
{
    public interface IUpdateDoctor
    {
        void Update(string firstName, string lastName, int contactNumber, int cpf, int doctorRegistration);
    }
}
