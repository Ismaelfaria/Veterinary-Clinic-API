
using System.Numerics;
using Veterinary_Clinic_API.App.RepositorysInterface;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.Adm
{
    public class AdmS : IAdmS
    {
        private readonly IAdminRepository _admin;

        public AdmS(IAdminRepository admin)
        {
            _admin = admin;
        }

        public Admin admCreate(Admin admin)
        {
            var roleAdm = "Adm";

            admin.Id = Guid.NewGuid();

            admin.Role = roleAdm;

            _admin.Create(admin);

            return admin;
        }
        public Admin FindByUserName(string name)
        {
            return _admin.FindByUserName(name);
        }
    }
}
