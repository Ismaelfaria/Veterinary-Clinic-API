using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.ConsultService
{
    public class CreateConsultService : ICreateConsult
    {
        private readonly ICreateConsultR _createRepository;

        public CreateConsultService(ICreateConsultR createRepository)
        {
            _createRepository = createRepository;
        }

        public Consultation Create(Consultation consult)
        {
            _createRepository.Create(consult);

            return consult;
        }
    }
}
