namespace Veterinary_Clinic_API.Domain.Entitys
{
    public class Doctor
    {
        public Doctor()
        {
            IsDeleted = false;
        }
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int ContactNumber { get; set; }
        public int Cpf { get; set; }
        public int DoctorRegistration { get; set; }
        public DateTime DateofRegistration { get; set; }
        public bool IsDeleted { get; set; }
        public void UpdateDoctor(string firstName, int contactNumber, int cpf, int doctorRegistration)
        {
            UserName = firstName;
            ContactNumber = contactNumber;
            Cpf = cpf;
            DoctorRegistration = doctorRegistration;
        }
        public void DeleteDoctor()
        {
            IsDeleted = true;
        }
    }
}
