using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class ExpenseForm_AddPreviousStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PreviousStatusId",
                table: "ExpenseForms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseForms_PreviousStatusId",
                table: "ExpenseForms",
                column: "PreviousStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseForms_ExpenseFormStatus_PreviousStatusId",
                table: "ExpenseForms",
                column: "PreviousStatusId",
                principalTable: "ExpenseFormStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseForms_ExpenseFormStatus_PreviousStatusId",
                table: "ExpenseForms");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseForms_PreviousStatusId",
                table: "ExpenseForms");

            migrationBuilder.DropColumn(
                name: "PreviousStatusId",
                table: "ExpenseForms");
        }
    }
}
