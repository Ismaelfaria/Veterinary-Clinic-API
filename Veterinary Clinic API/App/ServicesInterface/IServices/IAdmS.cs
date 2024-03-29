using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.ServicesInterface.ICreateService
{
    public interface IAdmS
    {
        Admin admCreate(Admin admin);
        Admin FindByUserName(string name);
    }
}
