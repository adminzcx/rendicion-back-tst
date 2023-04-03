using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Managment_Sector_UpdateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                update Managements set HasSpecialPermissions = 1 where Name = 'Finanzas'");

            migrationBuilder.Sql(@"
                update Sectors set HasSpecialPermissions = 1 where Name = 'Compras'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
