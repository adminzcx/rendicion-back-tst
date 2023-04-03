using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class LunchForm_AddCostPerLunch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CostPerLunch",
                table: "LunchForm",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ExceptionResponse",
                table: "LunchForm",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostPerLunch",
                table: "LunchForm");

            migrationBuilder.DropColumn(
                name: "ExceptionResponse",
                table: "LunchForm");
        }
    }
}
