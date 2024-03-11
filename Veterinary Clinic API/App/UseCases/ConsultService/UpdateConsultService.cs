using Veterinary_Clinic_API.App.RepositorysInterface.IUpdate;
using Veterinary_Clinic_API.App.ServicesInterface.IUpdateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.ConsultService
{
    public class UpdateConsultService : IUpdateConsult
    {
        private readonly IUpdateConsultR _updateRepository;

        public UpdateConsultService(IUpdateConsultR updateRepository)
        {
            _updateRepository = updateRepository;
        }

        public void Update(Guid id, Consultation consult)
        {
            _updateRepository.Update(id, consult);
        }
    }
}
