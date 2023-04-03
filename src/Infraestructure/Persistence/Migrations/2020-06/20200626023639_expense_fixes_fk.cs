using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class expense_fixes_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseFormAudits_ExpenseForms_ExpenseFormId",
                table: "ExpenseFormAudits");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseFormComments_ExpenseForms_ExpenseFormId",
                table: "ExpenseFormComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseForms_ExpenseFormId",
                table: "Expenses");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseFormAudits_ExpenseForms_ExpenseFormId",
                table: "ExpenseFormAudits",
                column: "ExpenseFormId",
                principalTable: "ExpenseForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseFormComments_ExpenseForms_ExpenseFormId",
                table: "ExpenseFormComments",
                column: "ExpenseFormId",
                principalTable: "ExpenseForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseForms_ExpenseFormId",
                table: "Expenses",
                column: "ExpenseFormId",
                principalTable: "ExpenseForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseFormAudits_ExpenseForms_ExpenseFormId",
                table: "ExpenseFormAudits");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseFormComments_ExpenseForms_ExpenseFormId",
                table: "ExpenseFormComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseForms_ExpenseFormId",
                table: "Expenses");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseFormAudits_ExpenseForms_ExpenseFormId",
                table: "ExpenseFormAudits",
                column: "ExpenseFormId",
                principalTable: "ExpenseForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseFormComments_ExpenseForms_ExpenseFormId",
                table: "ExpenseFormComments",
                column: "ExpenseFormId",
                principalTable: "ExpenseForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseForms_ExpenseFormId",
                table: "Expenses",
                column: "ExpenseFormId",
                principalTable: "ExpenseForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
