using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Position_AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                insert into Positions
                values 
                     ('ALL', 'Admin')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
