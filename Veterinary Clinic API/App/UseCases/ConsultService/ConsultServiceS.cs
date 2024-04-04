using FluentValidation;
using Veterinary_Clinic_API.App.RepositorysInterface;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.ConsultService
{
    public class ConsultServiceS : IConsult
    {
        private readonly IConsultRepository _consult;
        private readonly IClientRepository _client;
        private readonly IDoctorRepository _doctor;
        private readonly IValidator<Consultation> _validator;

        public ConsultServiceS(IConsultRepository consult, IClientRepository client, IDoctorRepository doctor, IValidator<Consultation> validator)
        {
            _consult = consult;
            _client = client;
            _doctor = doctor;
            _validator = validator;
        }
        public IEnumerable<Consultation> FindAll()
        {
            return _consult.FindAll();
        }

        public Consultation FindByIdConsult(Guid id)
        {
            return _consult.FindByIdConsult(id);
        }
        public Consultation Create(Consultation consult)
        {
            var validator = _validator.Validate(consult);

            if (!validator.IsValid)
            {
                throw new ValidationException("Erro de validação ao criar uma Consulta", validator.Errors);
            }

            var clientDatabase = _client.FindByCpf(consult.CpfClient);

            if (clientDatabase == null)
            {
                return null;
            }

            var doctorDatabase = _doctor.FindByRegister(consult.RegisterDoctor);

            if (doctorDatabase == null)
            {
                return null;
            }

            _consult.Create(consult);

            return consult;
        }
        public void Update(Guid id, Consultation consult)
        {
            _consult.Update(id, consult);
        }
        public void DeleteAndTerminated(Guid idConsultation)
        {
            _consult.DeleteAndTerminated(idConsultation);
        }
    }
}
