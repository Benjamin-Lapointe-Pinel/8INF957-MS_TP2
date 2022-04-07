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
    [Migration("20220406222945_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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
                            LastName = "Lapointe-Pinel"
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
                            LastName = "Tidjet"
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

                    b.Property<bool>("Diagnostic")
                        .HasColumnType("tinyint(1)");

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
                            Diagnostic = false,
                            FirstName = "Benjamin",
                            Gender = 0,
                            LastName = "Lapointe-Pinel"
                        },
                        new
                        {
                            Id = 2,
                            Birthdate = new DateTime(1995, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Rimouski",
                            Diagnostic = false,
                            FirstName = "Zaid",
                            Gender = 0,
                            LastName = "Tidjet"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}