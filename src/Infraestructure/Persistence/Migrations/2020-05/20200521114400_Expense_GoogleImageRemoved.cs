using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Expense_GoogleImageRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoogleImage",
                table: "Expenses");

            migrationBuilder.AlterColumn<double>(
                name: "SourceLongitude",
                table: "Expenses",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<double>(
                name: "SourceLatitude",
                table: "Expenses",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Expenses",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Expenses",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Device",
                table: "Expenses",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "SourceLongitude",
                table: "Expenses",
                type: "float",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(double),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SourceLatitude",
                table: "Expenses",
                type: "float",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(double),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Expenses",
                type: "float",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(double),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Expenses",
                type: "float",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(double),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Device",
                table: "Expenses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GoogleImage",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
