using FluentValidation;
using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.App.RepositorysInterface.IDelete;
using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.App.RepositorysInterface.IUpdate;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.ConsultService
{
    public class ConsultServiceS : IConsult
    {
        private readonly IUpdateConsultR _updateRepository;
        private readonly IGetConsultR _getRepository;
        private readonly ICreateConsultR _createRepository;
        private readonly IDeleteConsultR _deleteRepository;
        private readonly IGetClientR _getClientRepository;
        private readonly IGetDoctorR _getDoctorRepository;
        private readonly IValidator<Consultation> _validator;

        public ConsultServiceS(IUpdateConsultR updateRepository, IGetConsultR getRepository, IDeleteConsultR deleteRepository, ICreateConsultR createRepository, IGetClientR getClientRepository, IGetDoctorR getDoctorRepository, IValidator<Consultation> validator)
        {
            _createRepository = createRepository;
            _updateRepository = updateRepository;
            _getRepository = getRepository;
            _deleteRepository = deleteRepository;
            _getClientRepository = getClientRepository;
            _getDoctorRepository = getDoctorRepository;
            _validator = validator;
        }
        public IEnumerable<Consultation> FindAll()
        {
            return _getRepository.FindAll();
        }

        public Consultation FindByIdConsult(Guid id)
        {
            return _getRepository.FindByIdConsult(id);
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
        public void Update(Guid id, Consultation consult)
        {
            _updateRepository.Update(id, consult);
        }
        public void DeleteAndTerminated(Guid idConsultation)
        {
            _deleteRepository.DeleteAndTerminated(idConsultation);
        }
    }
}
