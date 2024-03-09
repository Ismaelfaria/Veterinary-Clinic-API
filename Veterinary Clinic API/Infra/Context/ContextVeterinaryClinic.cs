using Microsoft.EntityFrameworkCore;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.Infra.Context
{
    public class ContextVeterinaryClinic : DbContext
    {
        public ContextVeterinaryClinic(DbContextOptions<ContextVeterinaryClinic> options) : base(options)
        {}

        public DbSet<Client> Client { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Secretariat> Secretariat { get; set; }
        public DbSet<Consultation> Consult { get; set; }
    }
}
