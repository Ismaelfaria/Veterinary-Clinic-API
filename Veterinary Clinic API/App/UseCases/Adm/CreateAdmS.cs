
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.Adm
{
    public class CreateAdmS : ICreateAdmS
    {
        private readonly ICreateAdmS _createRepository;

        public CreateAdmS(ICreateAdmS createRepository)
        {
            _createRepository = createRepository;
        }

        public Admin admCreate(Admin admin)
        {
            admin.Id = Guid.NewGuid();

            _createRepository.admCreate(admin);

            return admin;
        }

        
    }
}
