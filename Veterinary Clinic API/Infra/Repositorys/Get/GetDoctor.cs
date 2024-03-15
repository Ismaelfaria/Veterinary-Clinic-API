using Veterinary_Clinic_API.App.RepositorysInterface.IGet;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;
using Veterinary_Clinic_API.Infra.Repositorys.Get;


public class GetDoctor : IGetDoctorR
{
    private readonly ContextVeterinaryClinic _context;
    public GetDoctor(ContextVeterinaryClinic context)
    {
        _context = context;
    }
    public IEnumerable<Doctor> FindAll()
    {
        var usersDatabase = _context.Doctor.Where(cl => !cl.IsDeleted).ToList();

        return usersDatabase;
    }

    public Doctor FindByRegister(int doctorRegister)
    {
        var userDatabase = _context.Doctor.SingleOrDefault(de => de.DoctorRegistration == doctorRegister);

        if (userDatabase == null)
        {
            return null;
        }
        return userDatabase;
    }

    public Doctor FindByUserName(string name)
    {
        var userDatabase = _context.Doctor.SingleOrDefault(de => de.UserName == name);

        if (userDatabase == null)
        {
            return null;
        }
        return userDatabase;
    }
}

