
using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

public class CreateSecretariat : ICreateSecretariatR
{
    private readonly ContextVeterinaryClinic _context;
    public CreateSecretariat(ContextVeterinaryClinic context)
    {
        _context = context;
    }
    public Secretariat Create(Secretariat secretariat)
    {
        _context.Secretariat.Add(secretariat);
        _context.SaveChanges();

        return secretariat;
    }

}

