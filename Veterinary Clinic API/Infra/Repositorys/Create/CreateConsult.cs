using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

namespace Veterinary_Clinic_API.Infra.Repositorys.Create
{
    public class CreateConsult : ICreateConsult
    {
        private readonly ContextVeterinaryClinic _context;
        public CreateConsult(ContextVeterinaryClinic context)
        {
            _context = context;
        }
        public void Create(Consultation consultation)
        {
            _context.Consult.Add(consultation);
            _context.SaveChanges();
        }
    }
}
