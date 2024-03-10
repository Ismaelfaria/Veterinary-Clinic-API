using Veterinary_Clinic_API.App.RepositorysInterface.IUpdate;
using Veterinary_Clinic_API.App.ServicesInterface.IUpdateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.ClientService
{
    public class UpdateService : IUpdateClient
    {
        private readonly IUpdateClientR _updateRepository;

        public UpdateService(IUpdateClientR updateRepository)
        {
            _updateRepository = updateRepository;
        }

        public void Update(int cpf, Client client)
        {
            _updateRepository.Update(cpf, client);
        }
    }
}
