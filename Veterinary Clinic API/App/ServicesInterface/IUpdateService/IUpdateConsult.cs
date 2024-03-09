using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.App.ServicesInterface.IUpdateService
{
    public interface IUpdateConsult
    {
        Consultation Update(int cpfClient, string symptoms, int registerDoctor, List<string> exames, string resultOfTheConsultation);
    }
}
