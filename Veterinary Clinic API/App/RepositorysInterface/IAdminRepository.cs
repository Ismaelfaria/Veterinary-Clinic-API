using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.RepositorysInterface
{
    public interface IAdminRepository
    {
        void Create(Admin adm);
        Admin FindByUserName(string name);
    }
}
