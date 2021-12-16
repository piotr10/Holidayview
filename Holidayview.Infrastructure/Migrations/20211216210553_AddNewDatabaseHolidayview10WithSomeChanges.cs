using Microsoft.EntityFrameworkCore.Migrations;

namespace Holidayview.Infrastructure.Migrations
{
    public partial class AddNewDatabaseHolidayview10WithSomeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerTypes_CustomerTypeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerTypeId",
                table: "Customers");

            migrationBuilder.CreateTable(
                name: "CustomerWithSupervisors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Leader = table.Column<string>(nullable: true),
                    Manager = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    CustomerTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerWithSupervisors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerWithSupervisors_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerWithSupervisors_CustomerTypes_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CustomerWithSupervisors",
                columns: new[] { "Id", "CustomerId", "CustomerTypeId", "Director", "Leader", "Manager" },
                values: new object[] { 1, 1, 1, "None", "None", "None" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerWithSupervisors_CustomerId",
                table: "CustomerWithSupervisors",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerWithSupervisors_CustomerTypeId",
                table: "CustomerWithSupervisors",
                column: "CustomerTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerWithSupervisors");

            migrationBuilder.AddColumn<int>(
                name: "CustomerTypeId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CustomerTypeId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerTypes_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId",
                principalTable: "CustomerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
