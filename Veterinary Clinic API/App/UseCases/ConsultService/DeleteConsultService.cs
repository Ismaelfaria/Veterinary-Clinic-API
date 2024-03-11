using Veterinary_Clinic_API.App.RepositorysInterface.IDelete;
using Veterinary_Clinic_API.App.ServicesInterface.IDeleteService;

namespace Veterinary_Clinic_API.App.UseCases.ConsultService
{
    public class DeleteConsultService:IDeleteConsult
    {
        private readonly IDeleteConsultR _deleteRepository;

        public DeleteConsultService(IDeleteConsultR deleteRepository)
        {
            _deleteRepository = deleteRepository;
        }

        public void DeleteAndTerminated(Guid idConsultation)
        {
            _deleteRepository.DeleteAndTerminated(idConsultation);
        }
    }
}
