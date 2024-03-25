using System;

namespace Veterinary_Clinic_API.Domain.Entitys
{
    public class Consultation
    {
        public Consultation()
        {
            ConsultationRegister = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            IdConsultation = Guid.NewGuid();

            ConsultationTerminated = false;
        }
        public Guid IdConsultation { get; private set; }
        public int CpfClient { get; private set; }
        public string Symptoms { get; private set; }
        public int RegisterDoctor { get; private set; }
        public List<string> Exames { get; private set; }
        public string ResultOfTheConsultation { get; private set; }
        public DateTime ConsultationRegister { get; private set; }
        public bool ConsultationTerminated { get; private set; }

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
