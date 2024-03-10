
using Microsoft.EntityFrameworkCore;
using Veterinary_Clinic_API.App.RepositorysInterface.IUpdate;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

public class UpdateClient : IUpdateClientR
{
    private readonly ContextVeterinaryClinic _context;
    public UpdateClient(ContextVeterinaryClinic context)
    {
        _context = context;
    }
    public void Update(int cpf, Client client)
    {
        var userDatabase = _context.Client.SingleOrDefault(de => de.Cpf == cpf);

        userDatabase.UpdateClient(client.FirstName, client.LastName,client.ContactNumber, client.Cpf, client.TypeOfAnimal, client.NameAnimal, client.SexAnimal, client.AgeAnimal);
        _context.SaveChanges();
    }
}

