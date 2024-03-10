using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.RepositorysInterface.IGet
{
    public interface IGetConsultR
    {
        IEnumerable<Consultation> FindAll();
        Consultation FindByIdConsult(Guid id);
    }
}
