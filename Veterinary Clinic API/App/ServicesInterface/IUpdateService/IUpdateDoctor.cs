using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.ServicesInterface.IUpdateService
{
    public interface IUpdateDoctor
    {
        void Update(Guid id, Doctor doctor);
    }
}
