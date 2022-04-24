﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestApi;

#nullable disable

namespace RestApi.Migrations
{
    [DbContext(typeof(TP2Context))]
    [Migration("20220424201450_ConfigIa")]
    partial class ConfigIa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RestApi.Models.ConfigurationIa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Distance")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("K")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId")
                        .IsUnique();

                    b.ToTable("ConfigurationsIa");
                });

            modelBuilder.Entity("RestApi.Models.DiagnosticDB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("CA")
                        .HasColumnType("float");

                    b.Property<float>("CP")
                        .HasColumnType("float");

                    b.Property<float>("OldPeak")
                        .HasColumnType("float");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<bool>("Target")
                        .HasColumnType("tinyint(1)");

                    b.Property<float>("Thal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Diagnostics");
                });

            modelBuilder.Entity("RestApi.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateEntryOffice")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthdate = new DateTime(1995, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Rimouski",
                            DateEntryOffice = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "blp@uqar.ca",
                            FirstName = "Benjamin",
                            Gender = 0,
                            LastName = "Lapointe-Pinel",
                            Password = "AQAAAAEAACcQAAAAELsCmXhzcIh5vc+Z9VOm2QjHNeaXkojGFkC4D3R1g/xGzDHuWM+HQ8HPaBftOfHdrw==",
                            Username = "blp"
                        },
                        new
                        {
                            Id = 2,
                            Birthdate = new DateTime(1995, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Rimouski",
                            DateEntryOffice = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "zt@uqar.ca",
                            FirstName = "Zaid",
                            Gender = 0,
                            LastName = "Tidjet",
                            Password = "AQAAAAEAACcQAAAAENNcoOF4SMZSyMi75UoG82D9sdGoJDKvCAz0jR5cO31gYCKDFdqShh7np75p9hn4tw==",
                            Username = "zt"
                        });
                });

            modelBuilder.Entity("RestApi.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("RestApi.Models.ConfigurationIa", b =>
                {
                    b.HasOne("RestApi.Models.Doctor", "Doctor")
                        .WithOne("ConfigurationIa")
                        .HasForeignKey("RestApi.Models.ConfigurationIa", "DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("RestApi.Models.DiagnosticDB", b =>
                {
                    b.HasOne("RestApi.Models.Patient", "Patient")
                        .WithMany("DiagnosticDBs")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("RestApi.Models.Patient", b =>
                {
                    b.HasOne("RestApi.Models.Doctor", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("RestApi.Models.Doctor", b =>
                {
                    b.Navigation("ConfigurationIa")
                        .IsRequired();

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("RestApi.Models.Patient", b =>
                {
                    b.Navigation("DiagnosticDBs");
                });
#pragma warning restore 612, 618
        }
    }
}
