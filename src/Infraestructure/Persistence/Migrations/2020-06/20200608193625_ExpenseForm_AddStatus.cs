using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class ExpenseForm_AddStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                insert into ExpenseFormStatus
                values 
                     ('En Revisión'),
                     ('Autorizada')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
