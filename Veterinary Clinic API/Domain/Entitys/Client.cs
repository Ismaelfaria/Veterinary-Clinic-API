namespace Veterinary_Clinic_API.Domain.Entitys
{
    public class Client
    {
        public Client()
        {
            IsDeleted = false;
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Cpf { get; set; }
        public int ContactNumber { get; set; }
        public string TypeOfAnimal { get; set; }
        public string NameAnimal { get; set; }
        public string SexAnimal { get; set; }
        public int AgeAnimal { get; set; }
        public DateTime DateofRegistration { get; set; }
        public bool IsDeleted { get; set; }
        public void UpdateDoctor(string firstName, string lastName, 
            int contactNumber, int cpf, string typeOfAnimal, string nameAnimal,
            string sexAnimal, int ageAnimal)
        {
            FirstName = firstName;
            LastName = lastName;
            Cpf = cpf;
            ContactNumber = contactNumber;
            TypeOfAnimal = typeOfAnimal;
            NameAnimal = nameAnimal;
            SexAnimal = sexAnimal;
            AgeAnimal = ageAnimal;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
