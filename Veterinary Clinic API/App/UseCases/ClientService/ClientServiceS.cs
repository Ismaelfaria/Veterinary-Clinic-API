using FluentValidation;
using Veterinary_Clinic_API.App.RepositorysInterface;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.ClientService
{
    public class ClientServiceS : IClient
    {
        private readonly IClientRepository _client;
        private readonly IValidator<Client> _validator;

        public ClientServiceS(IClientRepository client, IValidator<Client> validator)
        {
            _client = client;
            _validator = validator;
        }
        public IEnumerable<Client> FindAll()
        {
            return _client.FindAll();
        }

        public Client FindByCpf(int cpf)
        {
            return _client.FindByCpf(cpf);
        }

        public Client FindByUserName(string name)
        {
            return _client.FindByUserName(name);
        }
        public Client Create(Client client)
        {
            var validator = _validator.Validate(client);

            if (!validator.IsValid)
            {
                throw new ValidationException("Erro de validação ao criar um Client", validator.Errors);
            }

            _client.Create(client);

            return client;
        }
        public void Update(int cpf, Client client)
        {
            _client.Update(cpf, client);
        }
        public void Delete(Guid id)
        {
            _client.Delete(id);
        }
    }
}
