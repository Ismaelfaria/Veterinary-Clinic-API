using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.ClientService
{
    public class CreateService : ICreateClient
    {
        private readonly ICreateClientR _createRepository;

        public CreateService(ICreateClientR createRepository)
        {
            _createRepository = createRepository;
        }

        public Client Create(Client client)
        {
            _createRepository.Create(client);

            return client;
        }
    }
}
