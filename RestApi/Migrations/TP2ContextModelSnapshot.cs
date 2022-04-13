﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestApi;

#nullable disable

namespace RestApi.Migrations
{
    [DbContext(typeof(TP2Context))]
    partial class TP2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateEntryOffice")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
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
                            Password = "AQAAAAEAACcQAAAAEFbiw0PYmG4kIhkaH26Iia+dkuCEKOUgMvZ1g4c12R1ojTHNYF25n4QIrlmNh+LcyA==",
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
                            Password = "AQAAAAEAACcQAAAAEAFfPaEOY/C/7zYmYfRQJizMxXil3fPEn+TJFQO6JPDU4w6iHyBEpqIeREfLa94pvg==",
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
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthdate = new DateTime(1995, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Rimouski",
                            FirstName = "Benjamin",
                            Gender = 0,
                            LastName = "Lapointe-Pinel"
                        },
                        new
                        {
                            Id = 2,
                            Birthdate = new DateTime(1995, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Rimouski",
                            FirstName = "Zaid",
                            Gender = 0,
                            LastName = "Tidjet"
                        });
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
                    b.Navigation("DiagnosticDBs");
                });
#pragma warning restore 612, 618
        }
    }
}
