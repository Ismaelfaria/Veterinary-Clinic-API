﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Veterinary_Clinic_API.Infra.Context;

#nullable disable

namespace Veterinary_Clinic_API.Migrations
{
    [DbContext(typeof(ContextVeterinaryClinic))]
    [Migration("20240312201759_ClinicMigration")]
    partial class ClinicMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Veterinary_Clinic_API.Domain.Entitys.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AgeAnimal")
                        .HasColumnType("int");

                    b.Property<int>("ContactNumber")
                        .HasColumnType("int");

                    b.Property<int>("Cpf")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateofRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAnimal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SexAnimal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfAnimal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("Veterinary_Clinic_API.Domain.Entitys.Consultation", b =>
                {
                    b.Property<Guid>("IdConsultation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ConsultationRegister")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ConsultationTerminated")
                        .HasColumnType("bit");

                    b.Property<int>("CpfClient")
                        .HasColumnType("int");

                    b.Property<string>("Exames")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegisterDoctor")
                        .HasColumnType("int");

                    b.Property<string>("ResultOfTheConsultation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symptoms")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdConsultation");

                    b.ToTable("Consultation", (string)null);
                });

            modelBuilder.Entity("Veterinary_Clinic_API.Domain.Entitys.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ContactNumber")
                        .HasColumnType("int");

                    b.Property<int>("Cpf")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateofRegistration")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorRegistration")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctor", (string)null);
                });

            modelBuilder.Entity("Veterinary_Clinic_API.Domain.Entitys.Secretariat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ContactNumber")
                        .HasColumnType("int");

                    b.Property<int>("Cpf")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateofRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Secretariat", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
