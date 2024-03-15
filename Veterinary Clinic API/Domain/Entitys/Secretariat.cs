namespace Veterinary_Clinic_API.Domain.Entitys
{
    public class Secretariat
    {
        public Secretariat()
        {
            IsDeleted = false;
        }
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int ContactNumber { get; set; }
        public int Cpf { get; set; }
        public DateTime DateofRegistration { get; set; }
        public bool IsDeleted { get; set; }

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
