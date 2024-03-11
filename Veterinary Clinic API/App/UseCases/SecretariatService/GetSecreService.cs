using Veterinary_Clinic_API.App.RepositorysInterface.IDelete;
using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.App.ServicesInterface.IGetService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.SecretariatService
{
    public class GetSecreService : IGetSecretariat
    {
        private readonly IGetSecretariatR _getRepository;

        public GetSecreService(IGetSecretariatR getRepository)
        {
            _getRepository = getRepository;
        }
        public IEnumerable<Secretariat> FindAll()
        {
            return _getRepository.FindAll();
        }

        public Secretariat FindByCpf(int cpf)
        {
            return _getRepository.FindByCpf(cpf);
        }

        public Secretariat FindByUserName(string name)
        {
            return _getRepository.FindByUserName(name);
        }
    }
}
