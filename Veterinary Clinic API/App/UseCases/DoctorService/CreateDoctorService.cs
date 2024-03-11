using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.DoctorService
{
    public class CreateDoctorService : ICreateDoctor
    {
        private readonly ICreateDoctorR _createRepository;

        public CreateDoctorService(ICreateDoctorR createRepository)
        {
            _createRepository = createRepository;
        }
        public Doctor Create(Doctor doctor)
        {
            _createRepository.Create(doctor);

            return doctor;
        }
    }
}
