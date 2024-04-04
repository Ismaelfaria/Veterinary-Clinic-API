using Veterinary_Clinic_API.App.RepositorysInterface;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

namespace Veterinary_Clinic_API.Infra.Repositorys
{
    public class SecretariatRepository : ISecretariatRepository
    {
        private readonly ContextVeterinaryClinic _context;
        public SecretariatRepository(ContextVeterinaryClinic context)
        {
            _context = context;
        }
        public Secretariat Create(Secretariat secretariat)
        {
            _context.Secretariat.Add(secretariat);
            _context.SaveChanges();

            return secretariat;
        }
        public void Delete(Guid Id)
        {
            var userDatabase = _context.Secretariat.SingleOrDefault(de => de.Id == Id);

            userDatabase.DeleteSecretariat();
            _context.SaveChanges();
        }
        public IEnumerable<Secretariat> FindAll()
        {
            var usersDatabase = _context.Secretariat.Where(cl => !cl.IsDeleted).ToList();

            return usersDatabase;
        }
        public Secretariat FindByCpf(int cpf)
        {
            var userDatabase = _context.Secretariat.SingleOrDefault(de => de.Cpf == cpf);

            if (userDatabase == null)
            {
                return null;
            }
            return userDatabase;
        }
        public Secretariat FindByUserName(string name)
        {
            var userDatabase = _context.Secretariat.SingleOrDefault(de => de.UserName == name);

            if (userDatabase == null)
            {
                return null;
            }
            return userDatabase;
        }
        public void Update(Guid id, Secretariat secretariat)
        {
            var userDatabase = _context.Secretariat.SingleOrDefault(de => de.Id == id);
            userDatabase.UpdateSecretariat(secretariat.UserName, secretariat.ContactNumber, secretariat.Cpf);
            _context.SaveChanges();
        }
    }
}
