using FluentValidation;
using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.SecretariatService
{
    public class CreateSecreService : ICreateSecretariat
    {
        private readonly ICreateSecretariatR _createRepository;
        private readonly IValidator<Secretariat> _validator;

        public CreateSecreService(ICreateSecretariatR createRepository, IValidator<Secretariat> validator)
        {
            _createRepository = createRepository;
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
    }
}
