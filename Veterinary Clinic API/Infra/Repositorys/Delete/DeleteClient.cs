
using Veterinary_Clinic_API.App.RepositorysInterface.IDelete;
using Veterinary_Clinic_API.Infra.Context;

public class DeleteClient : IDeleteClient
{
    private readonly ContextVeterinaryClinic _context;
    public DeleteClient(ContextVeterinaryClinic context)
    {
        _context = context;
    }
    public bool Delete(Guid id)
    {
        var userDatabase = _context.Client.SingleOrDefault(de => de.Id == id);
        if(userDatabase == null)
        {
            return false;
        }

        userDatabase.Delete();
        _context.SaveChanges();
        return true;
    }
}

