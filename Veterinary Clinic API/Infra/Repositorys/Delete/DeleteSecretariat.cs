
using Veterinary_Clinic_API.App.RepositorysInterface.IDelete;
using Veterinary_Clinic_API.Infra.Context;

public class DeleteSecretariat : IDeleteSecretariatR
{
    private readonly ContextVeterinaryClinic _context;
    public DeleteSecretariat(ContextVeterinaryClinic context)
    {
        _context = context;
    }
    public void Delete(Guid Id)
    {
        var userDatabase = _context.Secretariat.SingleOrDefault(de => de.Id == Id);
        

        userDatabase.DeleteSecretariat();
        _context.SaveChanges();
        
    }
}

