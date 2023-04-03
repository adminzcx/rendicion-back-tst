using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Expense_Add_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StatusId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExpenseStatus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_StatusId",
                table: "Expenses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UserId",
                table: "Expenses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseStatus_StatusId",
                table: "Expenses",
                column: "StatusId",
                principalTable: "ExpenseStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseStatus_StatusId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "ExpenseStatus");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_StatusId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_UserId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Expenses");
        }
    }
}
