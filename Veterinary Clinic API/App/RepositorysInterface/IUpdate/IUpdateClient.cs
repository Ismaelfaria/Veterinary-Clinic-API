using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.RepositorysInterface.IUpdate
{
    public interface UpdateClient
    {
        Client Update(string firstName, string lastName,
            int contactNumber, int cpf, string typeOfAnimal, string nameAnimal,
            string sexAnimal, int ageAnimal);
    }
}
