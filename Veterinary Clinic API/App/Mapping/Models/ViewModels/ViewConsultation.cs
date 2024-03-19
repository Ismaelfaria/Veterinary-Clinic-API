namespace Veterinary_Clinic_API.App.Mapping.Models.ViewModels
{
    public class ViewConsultation
    {
        public Guid IdConsultation { get; set; }
        public int CpfClient { get; set; }
        public string Symptoms { get; set; }
        public int RegisterDoctor { get; set; }
        public List<string> Exames { get; set; }
        public string ResultOfTheConsultation { get; set; }
        public DateTime ConsultationRegister { get; set; }
    }
}
