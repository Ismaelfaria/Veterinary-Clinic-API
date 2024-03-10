using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.RepositorysInterface.IGet
{
    public interface IGetClientR
    {
        IEnumerable<Client> FindAll();
        Client FindByUserName(string name);
        Client FindByCpf(int cpf);
    }
}
