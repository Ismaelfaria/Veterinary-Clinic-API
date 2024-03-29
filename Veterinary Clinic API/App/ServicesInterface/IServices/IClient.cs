using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.ServicesInterface.ICreateService
{
    public interface IClient
    {
        Client Create(Client client);
        void Delete(Guid id);
        IEnumerable<Client> FindAll();
        Client FindByUserName(string name);
        Client FindByCpf(int cpf);
        void Update(int cpf, Client client);
    }
}
