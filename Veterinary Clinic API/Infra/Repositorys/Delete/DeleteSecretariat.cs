
using Veterinary_Clinic_API.App.RepositorysInterface.IDelete;
using Veterinary_Clinic_API.Infra.Context;

public class DeleteSecretariat : IDeleteSecretariat
{
    private readonly ContextVeterinaryClinic _context;
    public DeleteSecretariat(ContextVeterinaryClinic context)
    {
        _context = context;
    }
    public bool Delete(Guid Id)
    {
        var userDatabase = _context.Secretariat.SingleOrDefault(de => de.Id == Id);
        if (userDatabase == null)
        {
            return false;
        }

        userDatabase.DeleteSecretariat();
        _context.SaveChanges();
        return true;
    }
}

