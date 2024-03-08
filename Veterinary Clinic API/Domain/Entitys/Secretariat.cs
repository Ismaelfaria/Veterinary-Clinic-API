namespace Veterinary_Clinic_API.Domain.Entitys
{
    public class Secretariat
    {
        public Secretariat()
        {
            IsDeleted = false;
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactNumber { get; set; }
        public int Cpf { get; set; }
        public int EmployeeRegistration { get; set; }
        public DateTime DateofRegistration { get; set; }
        public bool IsDeleted { get; set; }

        public void UpdateSecretariat(string firstName, string lastName, int contactNumber, int cpf, int employeeRegistration)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            Cpf = cpf;
            EmployeeRegistration = employeeRegistration;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
