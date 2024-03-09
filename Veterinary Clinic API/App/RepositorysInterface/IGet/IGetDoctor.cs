using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.RepositorysInterface.IGet
{
    public interface IGetDoctor
    {
        IEnumerable<Doctor> FindAll();
        Doctor FindByUserName();
    }
}
