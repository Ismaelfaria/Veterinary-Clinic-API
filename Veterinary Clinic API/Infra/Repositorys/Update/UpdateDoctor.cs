
using System;
using Veterinary_Clinic_API.App.RepositorysInterface.IUpdate;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

public class UpdateDoctor : IUpdateDoctorR
{
    private readonly ContextVeterinaryClinic _context;
    public UpdateDoctor(ContextVeterinaryClinic context)
    {
        _context = context;
    }
    public void Update(Guid id, Doctor doctor)
    {
        var userDatabase = _context.Doctor.SingleOrDefault(de => de.Id == id);
        userDatabase.UpdateDoctor(doctor.UserName, doctor.ContactNumber, doctor.Cpf, doctor.DoctorRegistration);
        _context.SaveChanges();
    }
}

