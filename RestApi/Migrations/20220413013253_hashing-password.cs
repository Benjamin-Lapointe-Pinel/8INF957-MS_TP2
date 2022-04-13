using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApi.Migrations
{
    public partial class hashingpassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEHKyv5lc8RzqnGfk8nCAct9z7R0aWlXiV5Ec5eo/3k+tPhXT/FdLCvrZ7cyRlDwdHg==");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAEAACcQAAAAELV6ivJAQoxgDcxSvHq9KovGjRBeKH/v5AfPRG9gluchSGrU2PT+EExXV2rpcqPD5g==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "abc123");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "abc123");
        }
    }
}
