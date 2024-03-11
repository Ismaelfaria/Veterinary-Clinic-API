using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.ServicesInterface.IUpdateService
{
    public interface IUpdateSecretariat
    {
        void Update(Guid id, Secretariat secretariat);
    }
}
