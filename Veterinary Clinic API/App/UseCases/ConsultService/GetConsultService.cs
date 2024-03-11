using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.App.ServicesInterface.IGetService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.ConsultService
{
    public class GetConsultService : IGetConsult
    {
        private readonly IGetConsultR _getRepository;

        public GetConsultService(IGetConsultR getRepository)
        {
            _getRepository = getRepository;
        }
        public IEnumerable<Consultation> FindAll()
        {
            return _getRepository.FindAll();
        }

        public Consultation FindByIdConsult(Guid id)
        {
            return _getRepository.FindByIdConsult(id);
        }
    }
}
