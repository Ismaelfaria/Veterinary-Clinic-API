using FluentValidation;
using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.ClientService
{
    public class CreateClientService : ICreateClient
    {
        private readonly ICreateClientR _createRepository;
        private readonly IValidator<Client> _validator;

        public CreateClientService(ICreateClientR createRepository, IValidator<Client> validator)
        {
            _createRepository = createRepository;
            _validator = validator;
        }

        public Client Create(Client client)
        {
            var validator = _validator.Validate(client);

            if (!validator.IsValid)
            {
                throw new ValidationException("Erro de validação ao criar um Client", validator.Errors);
            }

            client.DateofRegistration = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            client.Id = Guid.NewGuid();

            _createRepository.Create(client);

            return client;
        }
    }
}
