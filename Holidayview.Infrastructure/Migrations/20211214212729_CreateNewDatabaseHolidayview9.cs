using Microsoft.EntityFrameworkCore.Migrations;

namespace Holidayview.Infrastructure.Migrations
{
    public partial class CreateNewDatabaseHolidayview9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name", "Surname" },
                values: new object[] { "admin@gmail.com", "admin", "admin" });

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Surname",
                value: "None");

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Surname",
                value: "Wick");

            migrationBuilder.UpdateData(
                table: "Leaders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Surname",
                value: "None");

            migrationBuilder.UpdateData(
                table: "Leaders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Surname",
                value: "Murray");

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Surname",
                value: "None");

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Surname",
                value: "Wahlberg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name", "Surname" },
                values: new object[] { "YES", "None", "YES" });

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Surname",
                value: null);

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Surname",
                value: null);

            migrationBuilder.UpdateData(
                table: "Leaders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Surname",
                value: null);

            migrationBuilder.UpdateData(
                table: "Leaders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Surname",
                value: null);

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Surname",
                value: null);

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Surname",
                value: null);
        }
    }
}
