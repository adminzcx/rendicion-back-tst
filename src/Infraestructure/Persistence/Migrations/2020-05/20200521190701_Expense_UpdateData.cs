using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Expense_UpdateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                update Concepts set reasonId=1 where id in (6,7)");

            migrationBuilder.Sql(@"
                insert into Segments
                values 
                     ('Servicio'),
                     ('Transporte') 
                      ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
