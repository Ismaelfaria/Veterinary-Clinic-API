using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.ServicesInterface.IUpdateService
{
    public interface IUpdateConsult
    {
        void Update(Guid id, Consultation consult);

    }
}
