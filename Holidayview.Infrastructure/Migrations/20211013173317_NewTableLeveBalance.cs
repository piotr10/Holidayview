using Microsoft.EntityFrameworkCore.Migrations;

namespace Holidayview.Infrastructure.Migrations
{
    public partial class NewTableLeveBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceOfLeave",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LeaveLeft",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LeaveTaken",
                table: "Customers");

            migrationBuilder.CreateTable(
                name: "LeaveBalances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BalanceOfLeave = table.Column<double>(nullable: false),
                    LeaveLeft = table.Column<double>(nullable: false),
                    LeaveTaken = table.Column<double>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveBalances_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveBalances_CustomerId",
                table: "LeaveBalances",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveBalances");

            migrationBuilder.AddColumn<double>(
                name: "BalanceOfLeave",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LeaveLeft",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LeaveTaken",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
