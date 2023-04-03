using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class ExpenseStatus_AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                insert into ExpenseStatus
                values 
                     ('Aprobada')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
