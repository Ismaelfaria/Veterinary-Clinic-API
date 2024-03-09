

using Veterinary_Clinic_API.App.RepositorysInterface.IUpdate;
using Veterinary_Clinic_API.Domain.Entitys;

public class UpdateClient : IUpdateConsult
{
    public Client Update(string firstName, string lastName, int contactNumber, int cpf, string typeOfAnimal, string nameAnimal, string sexAnimal, int ageAnimal)
    {
        throw new NotImplementedException();
    }

    public Consultation Update(int cpfClient, string symptoms, int registerDoctor, List<string> exames, string resultOfTheConsultation)
    {
        throw new NotImplementedException();
    }
}

