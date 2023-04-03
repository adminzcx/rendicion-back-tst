using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Expense_Add_ExpenseStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                insert into ExpenseStatus
                values 
                     ('Presentado')
                    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
