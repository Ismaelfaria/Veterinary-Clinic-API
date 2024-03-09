namespace Veterinary_Clinic_API.App.ServicesInterface.IDeleteService
{
    public interface IDeleteConsult
    {
        bool DeleteAndTerminated(Guid idConsultation);
    }
}
