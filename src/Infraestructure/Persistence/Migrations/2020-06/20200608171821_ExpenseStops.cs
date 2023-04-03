using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class ExpenseStops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseStops",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonId = table.Column<long>(nullable: false),
                    ConceptId = table.Column<long>(nullable: false),
                    ValidityStartDate = table.Column<DateTime>(nullable: false),
                    CapAmount = table.Column<decimal>(nullable: true),
                    TypeStop = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseStops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseStops_Concepts_ConceptId",
                        column: x => x.ConceptId,
                        principalTable: "Concepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExpenseStops_Reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "Reasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseStops_ConceptId",
                table: "ExpenseStops",
                column: "ConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseStops_ReasonId",
                table: "ExpenseStops",
                column: "ReasonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseStops");
        }
    }
}
