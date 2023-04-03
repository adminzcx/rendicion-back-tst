using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class ExpenseForm_NameUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                update ExpenseFormStatus set Name='Presentado' where id in (1)");

            migrationBuilder.Sql(@"
                update ExpenseFormStatus set Name='Aprobado' where id in (2)");

            migrationBuilder.Sql(@"
                update ExpenseFormStatus set Name='Rechazado' where id in (3)");

            migrationBuilder.Sql(@"
                update ExpenseFormStatus set Name='Revisado' where id in (4)");

            migrationBuilder.Sql(@"
                update ExpenseFormStatus set Name='Autorizado' where id in (5)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
