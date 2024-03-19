using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinary_Clinic_API.Migrations
{
    /// <inheritdoc />
    public partial class AuthenticationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Secretariat");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Doctor");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Secretariat",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Doctor",
                newName: "UserName");

            migrationBuilder.AddColumn<int>(
                name: "Password",
                table: "Secretariat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Password",
                table: "Doctor",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Secretariat");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Doctor");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Secretariat",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Doctor",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Secretariat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
