namespace Veterinary_Clinic_API.App.Mapping.Models.InputModels
{
    public class InputClient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Cpf { get; set; }
        public int ContactNumber { get; set; }
        public string TypeOfAnimal { get; set; }
        public string NameAnimal { get; set; }
        public string SexAnimal { get; set; }
        public int AgeAnimal { get; set; }
    }
}
