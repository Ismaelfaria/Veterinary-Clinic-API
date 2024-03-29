
using System.Numerics;
using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.Adm
{
    public class AdmS : IAdmS
    {
        private readonly ICreateAdmR _createRepository;
        private readonly IGetAdminR _getRepository;

        public AdmS(ICreateAdmR createRepository, IGetAdminR getRepository)
        {
            _createRepository = createRepository;
            _getRepository = getRepository;
        }

        public Admin admCreate(Admin admin)
        {
            var roleAdm = "Adm";

            admin.Id = Guid.NewGuid();

            admin.Role = roleAdm;

            _createRepository.Create(admin);

            return admin;
        }
        public Admin FindByUserName(string name)
        {
            return _getRepository.FindByUserName(name);
        }
    }
}
