namespace Veterinary_Clinic_API.Domain.Entitys
{
    public class Client
    {
        public Client()
        {
            DateofRegistration = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            Id = Guid.NewGuid();

            IsDeleted = false;
        }
        public Guid Id { get;private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Cpf { get; private set; }
        public int ContactNumber { get; private set; }
        public string TypeOfAnimal { get; private set; }
        public string NameAnimal { get; private set; }
        public string SexAnimal { get; private set; }
        public int AgeAnimal { get; private set; }
        public DateTime DateofRegistration { get; private set; }
        public bool IsDeleted { get; private set; }
        public void UpdateClient(string firstName, string lastName, 
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
