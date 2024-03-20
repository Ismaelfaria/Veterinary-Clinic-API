
using System.Numerics;
using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.Adm
{
    public class CreateAdmS : ICreateAdmS
    {
        private readonly ICreateAdmR _createRepository;

        public CreateAdmS(ICreateAdmR createRepository)
        {
            _createRepository = createRepository;
        }

        public Admin admCreate(Admin admin)
        {
            var roleAdm = "Adm";

            admin.Id = Guid.NewGuid();

            admin.Role = roleAdm;

            _createRepository.Create(admin);

            return admin;
        }

        
    }
}
