namespace Veterinary_Clinic_API.Domain.Entitys
{
    public class Secretariat
    {
        public Secretariat()
        {
            DateofRegistration = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            Id = Guid.NewGuid();

            IsDeleted = false;
        }
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Role { get; set; }
        public int ContactNumber { get; private set; }
        public int Cpf { get; private set; }
        public DateTime DateofRegistration { get; private set; }
        public bool IsDeleted { get; private set; }

        public void UpdateSecretariat(string firstName, int contactNumber, int cpf)
        {
            UserName = firstName;
            ContactNumber = contactNumber;
            Cpf = cpf;
        }
        public void DeleteSecretariat()
        {
            IsDeleted = true;
        }
    }
}
