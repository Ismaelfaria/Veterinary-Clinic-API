using Veterinary_Clinic_API.App.RepositorysInterface.IDelete;
using Veterinary_Clinic_API.App.ServicesInterface.IDeleteService;

namespace Veterinary_Clinic_API.App.UseCases.DoctorService
{
    public class DeleteDoctorService : IDeleteDoctor
    {
        private readonly IDeleteDoctorR _deleteRepository;

        public DeleteDoctorService(IDeleteDoctorR deleteRepository)
        {
            _deleteRepository = deleteRepository;
        }
        public void Delete(Guid id)
        {
            _deleteRepository.Delete(id);
        }
    }
}
