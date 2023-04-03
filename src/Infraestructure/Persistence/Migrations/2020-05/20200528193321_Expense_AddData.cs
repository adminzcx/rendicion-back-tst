using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Expense_AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                insert into ExpenseFormStatus
                values 
                     ('Presentada'),
                     ('Aprobada') ,
                     ('Rechazada') 
                      ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
