using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.ServicesInterface.ICreateService
{
    public interface IDoctor
    {
        Doctor Create(Doctor doctor);
        void Delete(Guid id);
        IEnumerable<Doctor> FindAll();
        Doctor FindByUserName(string name);
        Doctor FindByRegister(int doctorRegister);
        void Update(Guid id, Doctor doctor);

    }
}
