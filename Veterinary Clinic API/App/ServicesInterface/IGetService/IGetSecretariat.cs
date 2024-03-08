using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.ServicesInterface.IGetService
{
    public interface IGetSecretariat
    {
        IEnumerable<Secretariat> FindAll();
        Secretariat FindByUserName();
    }
}
