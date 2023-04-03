using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class PositionConfiguration_CreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PositionConfigurations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionId = table.Column<long>(nullable: false),
                    ReasonId = table.Column<long>(nullable: false),
                    ConceptId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PositionConfigurations_Concepts_ConceptId",
                        column: x => x.ConceptId,
                        principalTable: "Concepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PositionConfigurations_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PositionConfigurations_Reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "Reasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PositionConfigurations_ConceptId",
                table: "PositionConfigurations",
                column: "ConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionConfigurations_PositionId",
                table: "PositionConfigurations",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionConfigurations_ReasonId",
                table: "PositionConfigurations",
                column: "ReasonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PositionConfigurations");
        }
    }
}
