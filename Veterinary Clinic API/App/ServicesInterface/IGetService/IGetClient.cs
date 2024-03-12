using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.ServicesInterface.IGetService
{
    public interface IGetClient
    {
        IEnumerable<Client> FindAll();
        Client FindByUserName(string name);
        Client FindByCpf(int cpf);
    }
}
