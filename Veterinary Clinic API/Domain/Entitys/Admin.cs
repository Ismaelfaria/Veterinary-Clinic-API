namespace Veterinary_Clinic_API.Domain.Entitys
{
    public class Admin
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
