using Veterinary_Clinic_API.App.RepositorysInterface.IDelete;
using Veterinary_Clinic_API.App.ServicesInterface.IDeleteService;

namespace Veterinary_Clinic_API.App.UseCases.ClientService
{
    public class DeleteService : IDeleteClient
    {
        private readonly IDeleteClientR _deleteRepository;

        public DeleteService(IDeleteClientR deleteRepository)
        {
            _deleteRepository = deleteRepository;
        }

        public void Delete(Guid id)
        {
            _deleteRepository.Delete(id);
        }
    }
}
