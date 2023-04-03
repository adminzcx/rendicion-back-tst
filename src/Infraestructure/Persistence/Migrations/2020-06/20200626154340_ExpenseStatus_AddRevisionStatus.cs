using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class ExpenseStatus_AddRevisionStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "RevertEnabled",
                table: "Expenses",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            //migrationBuilder.Sql(@"
            //    insert into ExpenseStatus
            //    values 
            //         ('Revisada')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "RevertEnabled",
                table: "Expenses",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
