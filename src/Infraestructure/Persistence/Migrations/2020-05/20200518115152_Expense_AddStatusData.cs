using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Expense_AddStatusData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                insert into ExpenseStatus
                values 
                     ('Pendiente'),
                     ('Aprobado') ,
                     ('Rechazado') 
                      ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
