using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.RepositorysInterface.IGet
{
    public interface IGetSecretariatR
    {
        IEnumerable<Secretariat> FindAll();
        Secretariat FindByUserName(string name);
        Secretariat FindByCpf(int cpf);
    }
}
