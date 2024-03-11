using Veterinary_Clinic_API.App.RepositorysInterface.IUpdate;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

namespace Veterinary_Clinic_API.Infra.Repositorys.Update
{
    public class UpdateConsult : IUpdateConsultR
    {
        private readonly ContextVeterinaryClinic _context;
        public UpdateConsult(ContextVeterinaryClinic context)
        {
            _context = context;
        }
        public void Update(Guid id, Consultation consult)
        {
            var userDatabase = _context.Consult.SingleOrDefault(de => de.IdConsultation == id);

            userDatabase.UpdateConsultation(consult.CpfClient, consult.Symptoms, consult.RegisterDoctor, consult.Exames, consult.ResultOfTheConsultation);
            _context.SaveChanges();
        }
    }
}
