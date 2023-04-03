using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class ExpenseForm_AddReset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<bool>(
                name: "IsReset",
                table: "ExpenseForms",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<bool>(
                name: "IsReset",
                table: "Expenses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
