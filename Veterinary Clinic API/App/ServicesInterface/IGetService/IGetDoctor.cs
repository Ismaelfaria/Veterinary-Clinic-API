using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.ServicesInterface.IGetService
{
    public interface IGetDoctor
    {
        IEnumerable<Doctor> FindAll();
        Doctor FindByUserName(string name);
        Doctor FindByRegister(int doctorRegister);
    }
}
