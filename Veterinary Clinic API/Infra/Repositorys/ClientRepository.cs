using Veterinary_Clinic_API.App.RepositorysInterface;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

namespace Veterinary_Clinic_API.Infra.Repositorys
{
    public class ClientRepository : IClientRepository
    {
        private readonly ContextVeterinaryClinic _context;
        public ClientRepository(ContextVeterinaryClinic context)
        {
            _context = context;
        }
        public void Create(Client client)
        {
            _context.Client.Add(client);
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var userDatabase = _context.Client.SingleOrDefault(de => de.Id == id);

            userDatabase.Delete();
            _context.SaveChanges();
        }
        public IEnumerable<Client> FindAll()
        {
            var usersDatabase = _context.Client.Where(cl => !cl.IsDeleted).ToList();

            return usersDatabase;
        }

        public Client FindByCpf(int cpf)
        {
            var userDatabase = _context.Client.SingleOrDefault(de => de.Cpf == cpf);

            if (userDatabase == null)
            {
                return null;
            }

            return userDatabase;

        }

        public Client FindByUserName(string name)
        {
            var userDatabase = _context.Client.SingleOrDefault(de => de.FirstName == name);

            if (userDatabase == null)
            {
                return null;
            }

            return userDatabase;
        }
        public void Update(int cpf, Client client)
        {
            var userDatabase = _context.Client.SingleOrDefault(de => de.Cpf == cpf);

            userDatabase.UpdateClient(client.FirstName, client.LastName, client.ContactNumber, client.Cpf, client.TypeOfAnimal, client.NameAnimal, client.SexAnimal, client.AgeAnimal);
            _context.SaveChanges();
        }
    }
}
