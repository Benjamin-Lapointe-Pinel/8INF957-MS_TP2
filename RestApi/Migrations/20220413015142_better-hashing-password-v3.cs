using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApi.Migrations
{
    public partial class betterhashingpasswordv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEFbiw0PYmG4kIhkaH26Iia+dkuCEKOUgMvZ1g4c12R1ojTHNYF25n4QIrlmNh+LcyA==");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEAFfPaEOY/C/7zYmYfRQJizMxXil3fPEn+TJFQO6JPDU4w6iHyBEpqIeREfLa94pvg==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
