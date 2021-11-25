using Microsoft.EntityFrameworkCore.Migrations;

namespace Holidayview.Infrastructure.Migrations
{
    public partial class AddNewColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Managers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Leaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Directors",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Customers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Leaders");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Customers");
        }
    }
}
