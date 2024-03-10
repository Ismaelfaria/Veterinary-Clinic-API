
using Veterinary_Clinic_API.App.RepositorysInterface.IDelete;
using Veterinary_Clinic_API.Infra.Context;

public class DeleteClient : IDeleteClientR
{
    private readonly ContextVeterinaryClinic _context;
    public DeleteClient(ContextVeterinaryClinic context)
    {
        _context = context;
    }
    public void Delete(Guid id)
    {
        var userDatabase = _context.Client.SingleOrDefault(de => de.Id == id);

        userDatabase.Delete();
        _context.SaveChanges();
    }
}

