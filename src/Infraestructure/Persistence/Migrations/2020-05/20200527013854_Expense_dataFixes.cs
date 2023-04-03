using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Expense_dataFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                update Reasons set name = 'Viáticos en Capacitación' where Id=2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
