using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateEntryOffice = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Diagnostic = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Birthdate", "City", "DateEntryOffice", "Email", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1995, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rimouski", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "blp@uqar.ca", "Benjamin", 0, "Lapointe-Pinel" },
                    { 2, new DateTime(1995, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rimouski", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "zt@uqar.ca", "Zaid", 0, "Tidjet" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Birthdate", "City", "Diagnostic", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1995, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rimouski", false, "Benjamin", 0, "Lapointe-Pinel" },
                    { 2, new DateTime(1995, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rimouski", false, "Zaid", 0, "Tidjet" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
