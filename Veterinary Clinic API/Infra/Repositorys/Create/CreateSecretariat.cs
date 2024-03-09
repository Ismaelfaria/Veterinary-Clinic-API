
using Veterinary_Clinic_API.App.ServicesInterface.ICreateService;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

public class CreateSecretariat : ICreateSecretariat
{
    private readonly ContextVeterinaryClinic _context;
    public CreateSecretariat(ContextVeterinaryClinic context)
    {
        _context = context;
    }
    public void Create(Secretariat secretariat)
    {
        _context.Secretariat.Add(secretariat);
        _context.SaveChanges();
    }
}

