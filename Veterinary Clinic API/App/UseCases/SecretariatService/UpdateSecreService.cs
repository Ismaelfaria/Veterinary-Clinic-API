using Veterinary_Clinic_API.App.RepositorysInterface.IUpdate;
using Veterinary_Clinic_API.App.ServicesInterface.IUpdateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.SecretariatService
{
    public class UpdateSecreService : IUpdateSecretariat
    {
        private readonly IUpdateSecretariatR _updateRepository;

        public UpdateSecreService(IUpdateSecretariatR updateRepository)
        {
            _updateRepository = updateRepository;
        }
        public void Update(Guid id, Secretariat secretariat)
        {
            _updateRepository.Update(id, secretariat);
        }
    }
}
