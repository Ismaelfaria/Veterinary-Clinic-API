using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.ConsultService
{
    public class CreateConsultService : ICreateConsult
    {
        private readonly ICreateConsultR _createRepository;
        private readonly IGetClientR _getClientRepository;
        private readonly IGetDoctorR _getDoctorRepository;

        public CreateConsultService(ICreateConsultR createRepository, IGetClientR getClientRepository, IGetDoctorR getDoctorRepository)
        {
            _createRepository = createRepository;
            _getClientRepository = getClientRepository;
            _getDoctorRepository = getDoctorRepository;
        }

        public Consultation Create(Consultation consult)
        {
            var clientDatabase = _getClientRepository.FindByCpf(consult.CpfClient);

            if (clientDatabase == null)
            {
                return null;
            }

            var doctorDatabase = _getDoctorRepository.FindByRegister(consult.RegisterDoctor);

            if (doctorDatabase == null)
            {
                return null;
            }

            _createRepository.Create(consult);

            return consult;
        }
    }
}
