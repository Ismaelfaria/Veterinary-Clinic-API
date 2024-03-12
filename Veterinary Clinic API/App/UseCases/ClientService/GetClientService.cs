using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.App.ServicesInterface.IGetService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.ClientService
{
    public class GetClientService : IGetClient
    {
        private readonly IGetClientR _getRepository;

        public GetClientService(IGetClientR getRepository)
        {
            _getRepository = getRepository;
        }

        public IEnumerable<Client> FindAll()
        {
            return _getRepository.FindAll();
        }

        public Client FindByCpf(int cpf)
        {
            return _getRepository.FindByCpf(cpf);
        }

        public Client FindByUserName(string name)
        {
            return _getRepository.FindByUserName(name);
        }
    }
}
