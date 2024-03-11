using Veterinary_Clinic_API.App.RepositorysInterface.IUpdate;
using Veterinary_Clinic_API.App.ServicesInterface.IUpdateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.DoctorService
{
    public class UpdateDoctorService : IUpdateDoctor
    {
        private readonly IUpdateDoctorR _updateRepository;

        public UpdateDoctorService(IUpdateDoctorR updateRepository)
        {
            _updateRepository = updateRepository;
        }
        public void Update(Guid id, Doctor doctor)
        {
            _updateRepository.Update(id, doctor);
        }
    }
}
