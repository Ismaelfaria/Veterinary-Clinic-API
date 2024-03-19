namespace Veterinary_Clinic_API.App.Mapping.Models.ViewModels
{
    public class ViewClient
    {
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
    }
}
