using FluentValidation;
using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.App.RepositorysInterface.IDelete;
using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.App.RepositorysInterface.IUpdate;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.DoctorService
{
    public class DoctorService : IDoctor
    {
        private readonly IDeleteDoctorR _deleteRepository;
        private readonly IUpdateDoctorR _updateRepository;
        private readonly IGetDoctorR _getRepository;
        private readonly ICreateDoctorR _createRepository;
        private readonly IValidator<Doctor> _validator;

        public DoctorService(IUpdateDoctorR updateRepository, IDeleteDoctorR deleteRepository, IGetDoctorR getRepository, ICreateDoctorR createRepository, IValidator<Doctor> validator)
        {
            _updateRepository = updateRepository;
            _createRepository = createRepository;
            _deleteRepository = deleteRepository;
            _getRepository = getRepository;
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

            _createRepository.Create(doctor);

            return doctor;
        }
        public IEnumerable<Doctor> FindAll()
        {
            return _getRepository.FindAll();
        }

        public Doctor FindByRegister(int doctorRegister)
        {
            return _getRepository.FindByRegister(doctorRegister);
        }

        public Doctor FindByUserName(string name)
        {
            return _getRepository.FindByUserName(name);
        }
        public void Update(Guid id, Doctor doctor)
        {
            _updateRepository.Update(id, doctor);
        }
        public void Delete(Guid id)
        {
            _deleteRepository.Delete(id);
        }
    }
}
