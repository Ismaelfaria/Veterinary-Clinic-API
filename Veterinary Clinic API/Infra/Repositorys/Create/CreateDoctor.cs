
using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

public class CreateDoctor : ICreateDoctor
{
    private readonly ContextVeterinaryClinic _context;
    public CreateDoctor(ContextVeterinaryClinic context)
    {
        _context = context;
    }
    public void Create(Doctor doctor)
    {
        _context.Doctor.Add(doctor);
        _context.SaveChanges();
    }
}

