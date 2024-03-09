
using Veterinary_Clinic_API.App.RepositorysInterface.ICreate;
using Veterinary_Clinic_API.Domain.Entitys;
using Veterinary_Clinic_API.Infra.Context;

public class CreateClient : ICreateClient
{
    private readonly ContextVeterinaryClinic _context;
    public CreateClient(ContextVeterinaryClinic context)
    {
        _context = context;
    }
    public void Create(Client client)
    {
        _context.Client.Add(client);
        _context.SaveChanges();
    }
}
