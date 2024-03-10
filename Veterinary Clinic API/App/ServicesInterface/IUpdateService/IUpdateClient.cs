using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.ServicesInterface.IUpdateService
{
    public interface IUpdateClient
    {
        void Update(int cpf, Client client );
    }
}
