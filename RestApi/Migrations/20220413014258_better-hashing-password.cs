using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApi.Migrations
{
    public partial class betterhashingpassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEA+9HqP7QK9uuEPywM1UA2IAPBC0hgswE4FhNd8yruV4usUzDJS0+73NPOMo3oA76Q==");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEPoTwaow/vhHeCkXZ9WQgdYWQMUNZPzv0Njr5Si6eiMIr0GH+PYUJTQRS5dUsUWgtA==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
