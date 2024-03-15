using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.App.ServicesInterface.IGetService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.Adm
{
    public class GetAdminService : IGetAdminS
    {
        private readonly IGetAdminR _getRepository;

        public GetAdminService(IGetAdminR getRepository)
        {
            _getRepository = getRepository;
        }
        public Admin FindByUserName(string name)
        {
            return _getRepository.FindByUserName(name);
        }
    }
}
