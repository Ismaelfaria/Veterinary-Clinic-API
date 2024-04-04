using FluentValidation;
using Veterinary_Clinic_API.App.RepositorysInterface;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.SecretariatService
{
    public class SecreService : ISecretariat
    {
        private readonly ISecretariatRepository _secre;
        private readonly IValidator<Secretariat> _validator;

        public SecreService(ISecretariatRepository secre, IValidator<Secretariat> validator)
        {
            _secre = secre;
            _validator = validator;
        }
        public IEnumerable<Secretariat> FindAll()
        {
            return _secre.FindAll();
        }

        public Secretariat FindByCpf(int cpf)
        {
            return _secre.FindByCpf(cpf);
        }

        public Secretariat FindByUserName(string name)
        {
            return _secre.FindByUserName(name);
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

            _secre.Create(secretariat);

            return secretariat;
        }
        public void Update(Guid id, Secretariat secretariat)
        {
            _secre.Update(id, secretariat);
        }
        public void Delete(Guid id)
        {
            _secre.Delete(id);
        }
    }
}
