using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Expense_AddExpenseForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ExpenseFormId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExpenseFormStatus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseFormStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseForms",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: true),
                    PresentationDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    StatusId = table.Column<long>(nullable: false),
                    EmailSent = table.Column<bool>(nullable: false),
                    AdministratorUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseForms_Users_AdministratorUserId",
                        column: x => x.AdministratorUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpenseForms_ExpenseFormStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ExpenseFormStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpenseForms_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseFormId",
                table: "Expenses",
                column: "ExpenseFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseForms_AdministratorUserId",
                table: "ExpenseForms",
                column: "AdministratorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseForms_StatusId",
                table: "ExpenseForms",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseForms_UserId",
                table: "ExpenseForms",
                column: "UserId");

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
                name: "FK_Expenses_ExpenseForms_ExpenseFormId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "ExpenseForms");

            migrationBuilder.DropTable(
                name: "ExpenseFormStatus");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ExpenseFormId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpenseFormId",
                table: "Expenses");
        }
    }
}
