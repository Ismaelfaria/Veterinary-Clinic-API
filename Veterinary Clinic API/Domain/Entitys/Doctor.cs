namespace Veterinary_Clinic_API.Domain.Entitys
{
    public class Doctor
    {
        public Doctor()
        {
            IsDeleted = false;
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactNumber { get; set; }
        public int Cpf { get; set; }
        public int DoctorRegistration { get; set; }
        public DateTime DateofRegistration { get; set; }
        public bool IsDeleted { get; set; }
        public void UpdateDoctor(string firstName, string lastName, int contactNumber, int cpf, int doctorRegistration)
        {
            FirstName = firstName;
            LastName = lastName;
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
