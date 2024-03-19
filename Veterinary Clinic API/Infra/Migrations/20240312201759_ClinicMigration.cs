using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinary_Clinic_API.Migrations
{
    /// <inheritdoc />
    public partial class ClinicMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<int>(type: "int", nullable: false),
                    ContactNumber = table.Column<int>(type: "int", nullable: false),
                    TypeOfAnimal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAnimal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SexAnimal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeAnimal = table.Column<int>(type: "int", nullable: false),
                    DateofRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consultation",
                columns: table => new
                {
                    IdConsultation = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CpfClient = table.Column<int>(type: "int", nullable: false),
                    Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDoctor = table.Column<int>(type: "int", nullable: false),
                    Exames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResultOfTheConsultation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultationRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsultationTerminated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultation", x => x.IdConsultation);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<int>(type: "int", nullable: false),
                    Cpf = table.Column<int>(type: "int", nullable: false),
                    DoctorRegistration = table.Column<int>(type: "int", nullable: false),
                    DateofRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Secretariat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<int>(type: "int", nullable: false),
                    Cpf = table.Column<int>(type: "int", nullable: false),
                    DateofRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secretariat", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Consultation");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Secretariat");
        }
    }
}
