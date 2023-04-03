using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class ExpenseStatus_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                update ExpenseStatus set name='Autorizado' where id in (2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
