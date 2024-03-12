

using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

public class GetSecretariat : IGetSecretariatR
{

    private readonly ContextVeterinaryClinic _context;
    public GetSecretariat(ContextVeterinaryClinic context)
    {
        _context = context;
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
        var userDatabase = _context.Secretariat.SingleOrDefault(de => de.FirstName == name);

        if (userDatabase == null)
        {
            return null;
        }
        return userDatabase;
    }
}

