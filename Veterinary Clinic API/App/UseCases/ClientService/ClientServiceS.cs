using FluentValidation;
using Veterinary_Clinic_API.App.RepositorysInterface;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Domain.Events;
using Veterinary_Clinic_API.Infra.Menssaging;

namespace Veterinary_Clinic_API.App.UseCases.ClientService
{
    public class ClientServiceS : IClient
    {
        private readonly IClientRepository _client;
        private readonly IValidator<Client> _validator;
        private readonly IMessageBusService _messageBus;

        public ClientServiceS(IClientRepository client, IValidator<Client> validator, IMessageBusService messageBus)
        {
            _client = client;
            _validator = validator;
            _messageBus = messageBus;
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
            /*var validator = _validator.Validate(client);

            if (!validator.IsValid)
            {
                throw new ValidationException("Erro de validação ao criar um Client", validator.Errors);
            }

            _client.Create(client);*/

            var clientSaveEvent = new CreateClientEvent(client.Id, client.Cpf);

            _messageBus.Publish(clientSaveEvent, "order.created");

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
