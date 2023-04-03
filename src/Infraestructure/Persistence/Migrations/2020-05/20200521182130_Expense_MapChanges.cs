using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Expense_MapChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoogleURL",
                table: "Expenses");

            migrationBuilder.AddColumn<string>(
                name: "ImageMAP",
                table: "Expenses",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageMAP",
                table: "Expenses");

            migrationBuilder.AddColumn<string>(
                name: "GoogleURL",
                table: "Expenses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
