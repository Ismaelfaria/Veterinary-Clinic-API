using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.RepositorysInterface.IUpdate
{
    public interface IUpdateSecretariatR
    {
        void Update(Guid id, Secretariat secretariat);
    }
}
