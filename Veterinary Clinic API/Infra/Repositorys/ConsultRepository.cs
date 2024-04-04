using Veterinary_Clinic_API.App.RepositorysInterface;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

namespace Veterinary_Clinic_API.Infra.Repositorys
{
    public class ConsultRepository : IConsultRepository
    {
        private readonly ContextVeterinaryClinic _context;
        public ConsultRepository(ContextVeterinaryClinic context)
        {
            _context = context;
        }
        public void Create(Consultation consultation)
        {
            _context.Consult.Add(consultation);
            _context.SaveChanges();
        }
        public void DeleteAndTerminated(Guid idConsultation)
        {
            var userDatabase = _context.Consult.SingleOrDefault(de => de.IdConsultation == idConsultation);


            userDatabase.DeleteConsultation();
            _context.SaveChanges();

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
        public void Update(Guid id, Consultation consult)
        {
            var userDatabase = _context.Consult.SingleOrDefault(de => de.IdConsultation == id);

            userDatabase.UpdateConsultation(consult.CpfClient, consult.Symptoms, consult.RegisterDoctor, consult.Exames, consult.ResultOfTheConsultation);
            _context.SaveChanges();
        }
    }
}
