using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class LunchForm_AddStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                insert into LunchFormStatus
                values 
                     ('Borrador'),
                     ('Presentada'),
                     ('Aprobado'),
                     ('Rechazado'),
                     ('Revisado')
                      ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
