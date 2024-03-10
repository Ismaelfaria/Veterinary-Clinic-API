
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
    public bool Delete(Guid id)
    {
        var userDatabase = _context.Doctor.SingleOrDefault(de => de.Id == Id);
        if (userDatabase == null)
        {
            return false;
        }

        userDatabase.DeleteDoctor();
        _context.SaveChanges();
        return true;
    }
}

