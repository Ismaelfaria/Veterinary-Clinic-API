using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.RepositorysInterface
{
    public interface IConsultRepository
    {
        void Create(Consultation consultation);
        void DeleteAndTerminated(Guid idConsultation);
        IEnumerable<Consultation> FindAll();
        Consultation FindByIdConsult(Guid id);
        void Update(Guid id, Consultation consult);

    }
}
