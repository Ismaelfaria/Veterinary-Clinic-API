using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.ServicesInterface.ICreateService
{
    public interface IConsult
    {
        Consultation Create(Consultation consultation);
        void DeleteAndTerminated(Guid idConsultation);
        IEnumerable<Consultation> FindAll();
        Consultation FindByIdConsult(Guid id);
        void Update(Guid id, Consultation consult);

    }
}
