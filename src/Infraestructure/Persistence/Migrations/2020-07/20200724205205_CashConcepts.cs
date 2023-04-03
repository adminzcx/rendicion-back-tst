using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class CashConcepts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concept",
                table: "CashFormExpenses");

            migrationBuilder.DropColumn(
                name: "CostCenter",
                table: "CashFormExpenses");

            migrationBuilder.AddColumn<long>(
                name: "CashConceptId",
                table: "CashFormExpenses",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CostCenterId",
                table: "CashFormExpenses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CostCenters",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashConcepts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CostCenterId = table.Column<long>(nullable: true),
                    Calipso = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashConcepts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashConcepts_CostCenters_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "CostCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashFormExpenses_CashConceptId",
                table: "CashFormExpenses",
                column: "CashConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_CashFormExpenses_CostCenterId",
                table: "CashFormExpenses",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_CashConcepts_CostCenterId",
                table: "CashConcepts",
                column: "CostCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CashFormExpenses_CashConcepts_CashConceptId",
                table: "CashFormExpenses",
                column: "CashConceptId",
                principalTable: "CashConcepts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CashFormExpenses_CostCenters_CostCenterId",
                table: "CashFormExpenses",
                column: "CostCenterId",
                principalTable: "CostCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashFormExpenses_CashConcepts_CashConceptId",
                table: "CashFormExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_CashFormExpenses_CostCenters_CostCenterId",
                table: "CashFormExpenses");

            migrationBuilder.DropTable(
                name: "CashConcepts");

            migrationBuilder.DropTable(
                name: "CostCenters");

            migrationBuilder.DropIndex(
                name: "IX_CashFormExpenses_CashConceptId",
                table: "CashFormExpenses");

            migrationBuilder.DropIndex(
                name: "IX_CashFormExpenses_CostCenterId",
                table: "CashFormExpenses");

            migrationBuilder.DropColumn(
                name: "CashConceptId",
                table: "CashFormExpenses");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                table: "CashFormExpenses");

            migrationBuilder.AddColumn<string>(
                name: "Concept",
                table: "CashFormExpenses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CostCenter",
                table: "CashFormExpenses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
