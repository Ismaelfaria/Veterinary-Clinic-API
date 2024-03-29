using FluentValidation;
using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.App.RepositorysInterface.IDelete;
using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.App.RepositorysInterface.IUpdate;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.SecretariatService
{
    public class SecreService : ISecretariat
    {
        private readonly IDeleteSecretariatR _deleteRepository;
        private readonly IGetSecretariatR _getRepository;
        private readonly IUpdateSecretariatR _updateRepository;
        private readonly ICreateSecretariatR _createRepository;
        private readonly IValidator<Secretariat> _validator;

        public SecreService(IDeleteSecretariatR deleteRepository, IGetSecretariatR getRepository, IUpdateSecretariatR updateRepository, ICreateSecretariatR createRepository, IValidator<Secretariat> validator)
        {
            _deleteRepository = deleteRepository;
            _getRepository = getRepository;
            _createRepository = createRepository;
            _updateRepository = updateRepository;
        }
        public IEnumerable<Secretariat> FindAll()
        {
            return _getRepository.FindAll();
        }

        public Secretariat FindByCpf(int cpf)
        {
            return _getRepository.FindByCpf(cpf);
        }

        public Secretariat FindByUserName(string name)
        {
            return _getRepository.FindByUserName(name);
        }
        public Secretariat Create(Secretariat secretariat)
        {
            var roleSecret = "Secretaria";

            var validator = _validator.Validate(secretariat);

            if (!validator.IsValid)
            {
                throw new ValidationException("Erro de validação ao criar uma Secretaria", validator.Errors);
            }

            secretariat.Role = roleSecret;

            _createRepository.Create(secretariat);

            return secretariat;
        }
        public void Update(Guid id, Secretariat secretariat)
        {
            _updateRepository.Update(id, secretariat);
        }
        public void Delete(Guid id)
        {
            _deleteRepository.Delete(id);
        }
    }
}
