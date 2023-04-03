using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Expense_GoogleChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "SourceLongitude",
                table: "Expenses",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SourceLatitude",
                table: "Expenses",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Expenses",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Expenses",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Expenses",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceByKM",
                table: "Expenses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "PriceByKM",
                table: "Expenses");

            migrationBuilder.AlterColumn<string>(
                name: "SourceLongitude",
                table: "Expenses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(double),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "SourceLatitude",
                table: "Expenses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(double),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "Expenses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(double),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Expenses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(double),
                oldMaxLength: 50);
        }
    }
}
