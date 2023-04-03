using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class CashForm_configuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LunchFormAudit");

            migrationBuilder.CreateTable(
                name: "CashFormStatus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFormStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoneyTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    IsCoin = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organisms",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisms", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashFormStatus");

            migrationBuilder.DropTable(
                name: "MoneyTypes");

            migrationBuilder.DropTable(
                name: "Organisms");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LunchFormAudit",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
