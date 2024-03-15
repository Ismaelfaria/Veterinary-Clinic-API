using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

namespace Veterinary_Clinic_API.Infra.Repositorys.Create
{
    public class CreateAdm : ICreateAdmR
    {
        private readonly ContextVeterinaryClinic _context;
        public CreateAdm(ContextVeterinaryClinic context)
        {
            _context = context;
        }
       
        public void Create(Admin adm)
        {
            _context.Admin.Add(adm);
            _context.SaveChanges();
        }
    }
}
