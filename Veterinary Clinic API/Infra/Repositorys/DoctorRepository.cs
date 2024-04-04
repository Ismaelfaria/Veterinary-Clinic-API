using Veterinary_Clinic_API.App.RepositorysInterface;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

namespace Veterinary_Clinic_API.Infra.Repositorys
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ContextVeterinaryClinic _context;
        public DoctorRepository(ContextVeterinaryClinic context)
        {
            _context = context;
        }
        public void Create(Doctor doctor)
        {
            _context.Doctor.Add(doctor);
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var userDatabase = _context.Doctor.SingleOrDefault(de => de.Id == id);

            userDatabase.DeleteDoctor();
            _context.SaveChanges();
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
        public void Update(Guid id, Doctor doctor)
        {
            var userDatabase = _context.Doctor.SingleOrDefault(de => de.Id == id);
            userDatabase.UpdateDoctor(doctor.UserName, doctor.ContactNumber, doctor.Cpf, doctor.DoctorRegistration);
            _context.SaveChanges();
        }
    }
}
