using FluentValidation;
using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.App.RepositorysInterface.IDelete;
using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.App.RepositorysInterface.IUpdate;
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.UseCases.ClientService
{
    public class ClientServiceS : IClient
    {
        private readonly ICreateClientR _createRepository;
        private readonly IDeleteClientR _deleteRepository;
        private readonly IGetClientR _getRepository;
        private readonly IUpdateClientR _updateRepository;
        private readonly IValidator<Client> _validator;

        public ClientServiceS(IUpdateClientR updateRepository, IGetClientR getRepository, IDeleteClientR deleteRepository, ICreateClientR createRepository, IValidator<Client> validator)
        {
            _createRepository = createRepository;
            _deleteRepository = deleteRepository;
            _updateRepository = updateRepository;
            _getRepository = getRepository;
            _validator = validator;
        }
        public IEnumerable<Client> FindAll()
        {
            return _getRepository.FindAll();
        }

        public Client FindByCpf(int cpf)
        {
            return _getRepository.FindByCpf(cpf);
        }

        public Client FindByUserName(string name)
        {
            return _getRepository.FindByUserName(name);
        }
        public Client Create(Client client)
        {
            var validator = _validator.Validate(client);

            if (!validator.IsValid)
            {
                throw new ValidationException("Erro de validação ao criar um Client", validator.Errors);
            }

            _createRepository.Create(client);

            return client;
        }
        public void Update(int cpf, Client client)
        {
            _updateRepository.Update(cpf, client);
        }
        public void Delete(Guid id)
        {
            _deleteRepository.Delete(id);
        }
    }
}
