using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class User_Subzone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
               insert into SubZones
                values
                ('SIS', 'Norte 1', 1)");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
