using Veterinary_Clinic_API.App.RepositorysInterface.IDelete;
using Veterinary_Clinic_API.App.ServicesInterface.IDeleteService;

namespace Veterinary_Clinic_API.App.UseCases.ClientService
{
    public class DeleteClientService : IDeleteClient
    {
        private readonly IDeleteClientR _deleteRepository;

        public DeleteClientService(IDeleteClientR deleteRepository)
        {
            _deleteRepository = deleteRepository;
        }

        public void Delete(Guid id)
        {
            _deleteRepository.Delete(id);
        }
    }
}
