using FluentValidation;
using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.DoctorService
{
    public class CreateDoctorService : ICreateDoctor
    {
        private readonly ICreateDoctorR _createRepository;
        private readonly IValidator<Doctor> _validator;

        public CreateDoctorService(ICreateDoctorR createRepository, IValidator<Doctor> validator)
        {
            _createRepository = createRepository;
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
    }
}
