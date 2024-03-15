
using Veterinary_Clinic_API.App.RepositorysInterface.IUpdate;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

public class UpdateSecretariat : IUpdateSecretariatR
{
    private readonly ContextVeterinaryClinic _context;
    public UpdateSecretariat(ContextVeterinaryClinic context)
    {
        _context = context;
    }
    public void Update(Guid id, Secretariat secretariat)
    {
        var userDatabase = _context.Secretariat.SingleOrDefault(de => de.Id == id);
        userDatabase.UpdateSecretariat(secretariat.UserName, secretariat.ContactNumber, secretariat.Cpf);
        _context.SaveChanges();
    }
}

