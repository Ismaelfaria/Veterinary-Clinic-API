namespace Veterinary_Clinic_API.Domain.Entitys
{
    public class Consultation
    {
        public Consultation()
        {
            ConsultationTerminated = false;
        }
        public Guid IdConsultation { get; set; }
        public int CpfClient { get; set; }
        public string Symptoms { get; set; }
        public int RegisterDoctor { get; set; }
        public List<string> Exames { get; set; }
        public string ResultOfTheConsultation { get; set; }
        public DateTime ConsultationRegister { get; set; }
        public bool ConsultationTerminated { get; set; }

        public void UpdateConsultation(int cpfClient, string symptoms, int registerDoctor, List<string> exames, string resultOfTheConsultation)
        {
            CpfClient = cpfClient;
            Symptoms = symptoms;
            RegisterDoctor = registerDoctor;
            Exames = exames;
            ResultOfTheConsultation = resultOfTheConsultation;
        }
        public void DeleteConsultation()
        {
            ConsultationTerminated = true;
        }

    }
}
