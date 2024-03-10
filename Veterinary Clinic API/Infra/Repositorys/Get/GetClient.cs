using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

public class GetClient : IGetClientR
{
    private readonly ContextVeterinaryClinic _context;
    public GetClient(ContextVeterinaryClinic context)
    {
        _context = context;
    }
    public IEnumerable<Client> FindAll()
    {
        var usersDatabase = _context.Client.Where(cl => !cl.IsDeleted).ToList();

        return usersDatabase;
    }

    public Client FindByCpf(int cpf)
    {
        var userDatabase = _context.Client.SingleOrDefault(de => de.Cpf == cpf);

        if(userDatabase == null)
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
}

