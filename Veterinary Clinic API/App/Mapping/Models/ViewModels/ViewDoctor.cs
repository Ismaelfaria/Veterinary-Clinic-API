namespace Veterinary_Clinic_API.App.Mapping.Models.ViewModels
{
    public class ViewDoctor
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int ContactNumber { get; set; }
        public int Cpf { get; set; }
        public int DoctorRegistration { get; set; }
        public DateTime DateofRegistration { get; set; }
    }
}
