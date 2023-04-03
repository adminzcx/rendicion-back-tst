using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class ExpenseFormAudit_Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseFormAudits_ExpenseForms_ExpenseFormId",
                table: "ExpenseFormAudits");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseFormAudits_ExpenseFormStatus_StatusId",
                table: "ExpenseFormAudits");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseFormAudits_StatusId",
                table: "ExpenseFormAudits");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ExpenseFormAudits");

            migrationBuilder.AlterColumn<long>(
                name: "ExpenseFormId",
                table: "ExpenseFormAudits",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ExpenseFormAudits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ExpenseFormAudits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPosition",
                table: "ExpenseFormAudits",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseFormAudits_ExpenseForms_ExpenseFormId",
                table: "ExpenseFormAudits",
                column: "ExpenseFormId",
                principalTable: "ExpenseForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseFormAudits_ExpenseForms_ExpenseFormId",
                table: "ExpenseFormAudits");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ExpenseFormAudits");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ExpenseFormAudits");

            migrationBuilder.DropColumn(
                name: "UserPosition",
                table: "ExpenseFormAudits");

            migrationBuilder.AlterColumn<long>(
                name: "ExpenseFormId",
                table: "ExpenseFormAudits",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "StatusId",
                table: "ExpenseFormAudits",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseFormAudits_StatusId",
                table: "ExpenseFormAudits",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseFormAudits_ExpenseForms_ExpenseFormId",
                table: "ExpenseFormAudits",
                column: "ExpenseFormId",
                principalTable: "ExpenseForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseFormAudits_ExpenseFormStatus_StatusId",
                table: "ExpenseFormAudits",
                column: "StatusId",
                principalTable: "ExpenseFormStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
