using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.Infra.Repositorys.Get
{
    public class GetConsult : IGetConsult
    {
        public IEnumerable<Consultation> FindAll()
        {
            throw new NotImplementedException();
        }

        public Consultation FindByIdConsult()
        {
            throw new NotImplementedException();
        }
    }
}
