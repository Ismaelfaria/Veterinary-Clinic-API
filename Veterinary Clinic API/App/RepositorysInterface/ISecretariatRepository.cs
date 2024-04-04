using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.RepositorysInterface
{
    public interface ISecretariatRepository
    {
        Secretariat Create(Secretariat secretariat);
        void Delete(Guid id);
        IEnumerable<Secretariat> FindAll();
        Secretariat FindByUserName(string name);
        Secretariat FindByCpf(int cpf);
        void Update(Guid id, Secretariat secretariat);

    }
}
