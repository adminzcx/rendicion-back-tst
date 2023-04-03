using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Managment_Sector_AddHasSpecialPermissionsColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasSpecialPermissions",
                table: "Sectors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSpecialPermissions",
                table: "Managements",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasSpecialPermissions",
                table: "Sectors");

            migrationBuilder.DropColumn(
                name: "HasSpecialPermissions",
                table: "Managements");
        }
    }
}
