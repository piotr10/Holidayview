using Microsoft.EntityFrameworkCore.Migrations;

namespace Holidayview.Infrastructure.Migrations
{
    public partial class ChangetypeOfBalanceOfLeave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "LeaveDimension",
                table: "Vacations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LeaveDimension",
                table: "Vacations",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
