using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Expense_RejectReasonAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RejectReasonId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_RejectReasonId",
                table: "Expenses",
                column: "RejectReasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_RejectReasons_RejectReasonId",
                table: "Expenses",
                column: "RejectReasonId",
                principalTable: "RejectReasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_RejectReasons_RejectReasonId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_RejectReasonId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "RejectReasonId",
                table: "Expenses");
        }
    }
}
