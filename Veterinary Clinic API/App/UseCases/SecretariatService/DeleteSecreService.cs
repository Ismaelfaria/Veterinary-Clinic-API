using Veterinary_Clinic_API.App.RepositorysInterface.IDelete;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.App.ServicesInterface.IDeleteService;

namespace Veterinary_Clinic_API.App.UseCases.SecretariatService
{
    public class DeleteSecreService : IDeleteSecretariat
    {
        private readonly IDeleteSecretariatR _deleteRepository;

        public DeleteSecreService(IDeleteSecretariatR deleteRepository)
        {
            _deleteRepository = deleteRepository;
        }
        public void Delete(Guid id)
        {
            _deleteRepository.Delete(id);       
        }
    }
}
