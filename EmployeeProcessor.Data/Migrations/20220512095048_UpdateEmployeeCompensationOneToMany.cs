using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeProcessor.Data.Migrations
{
    public partial class UpdateEmployeeCompensationOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compensations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayType = table.Column<int>(type: "int", nullable: false),
                    AnnualSalaryAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PayPerHourAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compensations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeResponsibilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeRank = table.Column<int>(type: "int", nullable: false),
                    PayType = table.Column<int>(type: "int", nullable: false),
                    MaxExpenseAccount = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeResponsibilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompensationId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeResponsibilityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Compensations_CompensationId",
                        column: x => x.CompensationId,
                        principalTable: "Compensations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeResponsibilities_EmployeeResponsibilityId",
                        column: x => x.EmployeeResponsibilityId,
                        principalTable: "EmployeeResponsibilities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompensationId",
                table: "Employees",
                column: "CompensationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeResponsibilityId",
                table: "Employees",
                column: "EmployeeResponsibilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Compensations");

            migrationBuilder.DropTable(
                name: "EmployeeResponsibilities");
        }
    }
}
