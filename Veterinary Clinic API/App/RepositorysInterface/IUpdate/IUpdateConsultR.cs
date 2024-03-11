using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.RepositorysInterface.IUpdate
{
    public interface IUpdateConsultR
    {
        void Update(Guid id, Consultation consult);
    }
}
