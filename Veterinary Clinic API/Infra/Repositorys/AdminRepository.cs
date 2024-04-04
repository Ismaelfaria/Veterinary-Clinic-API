using Veterinary_Clinic_API.App.RepositorysInterface;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

namespace Veterinary_Clinic_API.Infra.Repositorys
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ContextVeterinaryClinic _context;
        public AdminRepository(ContextVeterinaryClinic context)
        {
            _context = context;
        }
        public void Create(Admin adm)
        {
            _context.Admin.Add(adm);
            _context.SaveChanges();
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
