using Microsoft.EntityFrameworkCore;
using Veterinary_Clinic_API.Domain.Entitys;

namespace Veterinary_Clinic_API.Infra.Context
{
    public class ContextVeterinaryClinic : DbContext
    {
        public ContextVeterinaryClinic(DbContextOptions<ContextVeterinaryClinic> options) : base(options)
        { }

        public DbSet<Client> Client { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Secretariat> Secretariat { get; set; }
        public DbSet<Consultation> Consult { get; set; }
        public DbSet<Admin> Admin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(e =>
            {
                e.HasKey(de => de.Id);
                e.ToTable("Client");
            });

            modelBuilder.Entity<Doctor>(e =>
            {
                e.HasKey(de => de.Id);
                e.ToTable("Doctor");
            });

            modelBuilder.Entity<Secretariat>(e =>
            {
                e.HasKey(de => de.Id);
                e.ToTable("Secretariat");
            });

            modelBuilder.Entity<Admin>(e =>
            {
                e.HasKey(de => de.Id);
                e.ToTable("Admin");
            });
            modelBuilder.Entity<Consultation>(e =>
            {
                e.HasKey(de => de.IdConsultation);
                e.ToTable("Consultation");
            });
        }
    }
}
