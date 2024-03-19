namespace Veterinary_Clinic_API.App.Mapping.Models.InputModels
{
    public class InputConsultation
    {
        public int CpfClient { get; set; }
        public string Symptoms { get; set; }
        public int RegisterDoctor { get; set; }
        public List<string> Exames { get; set; }
        public string ResultOfTheConsultation { get; set; }
    }
}
