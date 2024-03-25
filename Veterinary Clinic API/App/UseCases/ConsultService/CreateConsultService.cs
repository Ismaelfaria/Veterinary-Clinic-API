using FluentValidation;
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
        private readonly IValidator<Consultation> _validator;

        public CreateConsultService(ICreateConsultR createRepository, IGetClientR getClientRepository, IGetDoctorR getDoctorRepository, IValidator<Consultation> validator)
        {
            _createRepository = createRepository;
            _getClientRepository = getClientRepository;
            _getDoctorRepository = getDoctorRepository;
            _validator = validator;
        }

        public Consultation Create(Consultation consult)
        {
            var validator = _validator.Validate(consult);

            if (!validator.IsValid)
            {
                throw new ValidationException("Erro de validação ao criar uma Consulta", validator.Errors);
            }

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
