using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.RepositorysInterface.IUpdate
{
    public interface IUpdateDoctorR
    {
        void Update(Guid id, Doctor doctor);
    }
}
