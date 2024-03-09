namespace Veterinary_Clinic_API.App.RepositorysInterface.IDelete
{
    public interface IDeleteConsult
    {
        bool DeleteAndTerminated(Guid idConsultation);
    }
}
