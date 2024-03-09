using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.RepositorysInterface.IGet
{
    public interface IGetConsult
    {
        IEnumerable<Consultation> FindAll();
        Consultation FindByIdConsult();
    }
}
