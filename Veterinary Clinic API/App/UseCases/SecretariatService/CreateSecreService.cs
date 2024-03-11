using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.SecretariatService
{
    public class CreateSecreService : ICreateSecretariat
    {
        private readonly ICreateSecretariatR _createRepository;

        public CreateSecreService(ICreateSecretariatR createRepository)
        {
            _createRepository = createRepository;
        }
        public Secretariat Create(Secretariat secretariat)
        {
            _createRepository.Create(secretariat);

            return secretariat;

        }
    }
}
