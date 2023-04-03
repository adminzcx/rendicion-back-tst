using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class UserSubstitution_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseForms_ExpenseFormId",
                table: "Expenses");

            migrationBuilder.AlterColumn<long>(
                name: "ExpenseFormId",
                table: "ExpenseFormAudits",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "UserSubstitutions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    ReplaceByUserId = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubstitutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSubstitutions_Users_ReplaceByUserId",
                        column: x => x.ReplaceByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserSubstitutions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSubstitutions_ReplaceByUserId",
                table: "UserSubstitutions",
                column: "ReplaceByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubstitutions_UserId",
                table: "UserSubstitutions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseForms_ExpenseFormId",
                table: "Expenses",
                column: "ExpenseFormId",
                principalTable: "ExpenseForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseForms_ExpenseFormId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "UserSubstitutions");

            migrationBuilder.AlterColumn<long>(
                name: "ExpenseFormId",
                table: "ExpenseFormAudits",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseForms_ExpenseFormId",
                table: "Expenses",
                column: "ExpenseFormId",
                principalTable: "ExpenseForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
