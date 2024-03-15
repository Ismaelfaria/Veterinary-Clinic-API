using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

namespace Veterinary_Clinic_API.Infra.Repositorys.Get
{
    public class GetAdmin : IGetAdminR
    {
        private readonly ContextVeterinaryClinic _context;
        public GetAdmin(ContextVeterinaryClinic context)
        {
            _context = context;
        }
        public Admin FindByUserName(string name)
        {
            var userDatabase = _context.Admin.SingleOrDefault(de => de.Name == name);

            if (userDatabase == null)
            {
                return null;
            }

            return userDatabase;
        }
    }
}
