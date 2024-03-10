
using Veterinary_Clinic_API.App.RepositorysInterface.IDelete;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

public class DeleteDoctor : IDeleteDoctorR
{
    private readonly ContextVeterinaryClinic _context;
    public DeleteDoctor(ContextVeterinaryClinic context)
    {
        _context = context;
    }
    public void Delete(Guid id)
    {
        var userDatabase = _context.Doctor.SingleOrDefault(de => de.Id == id);
       

        userDatabase.DeleteDoctor();
        _context.SaveChanges();
        
    }
}

