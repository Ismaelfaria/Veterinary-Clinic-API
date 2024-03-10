using Microsoft.EntityFrameworkCore;
using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

namespace Veterinary_Clinic_API.Infra.Repositorys.Get
{
    public class GetConsult : IGetConsultR
    {
        private readonly ContextVeterinaryClinic _context;
        public GetConsult(ContextVeterinaryClinic context)
        {
            _context = context;
        }
        public IEnumerable<Consultation> FindAll()
        {
            var usersDatabase = _context.Consult.Where(cl => !cl.ConsultationTerminated).ToList();

            return usersDatabase;
        }

        public Consultation FindByIdConsult(Guid id)
        {
            var userDatabase = _context.Consult.SingleOrDefault(de => de.IdConsultation == id);

            if (userDatabase == null)
            {
                return null;
            }

            return userDatabase;
        }
    }
}
