using FluentValidation;
using Veterinary_Clinic_API.App.RepositorysInterface;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.DoctorService
{
    public class DoctorService : IDoctor
    {
        private readonly IDoctorRepository _doctor;
        private readonly IValidator<Doctor> _validator;

        public DoctorService(IDoctorRepository doctor, IValidator<Doctor> validator)
        {
            _doctor = doctor;
            _validator = validator;
        }
        public Doctor Create(Doctor doctor)
        {
            var roleDoctor = "Doutor";

            var validator = _validator.Validate(doctor);

            if (!validator.IsValid)
            {
                throw new ValidationException("Erro de validação ao criar um Doutor", validator.Errors);
            }

            doctor.Role = roleDoctor;

            _doctor.Create(doctor);

            return doctor;
        }
        public IEnumerable<Doctor> FindAll()
        {
            return _doctor.FindAll();
        }

        public Doctor FindByRegister(int doctorRegister)
        {
            return _doctor.FindByRegister(doctorRegister);
        }

        public Doctor FindByUserName(string name)
        {
            return _doctor.FindByUserName(name);
        }
        public void Update(Guid id, Doctor doctor)
        {
            _doctor.Update(id, doctor);
        }
        public void Delete(Guid id)
        {
            _doctor.Delete(id);
        }
    }
}
