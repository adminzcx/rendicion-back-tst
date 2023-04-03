using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class userAuthorizeExpenseForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AuthorizeUserId",
                table: "ExpenseForms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseForms_AuthorizeUserId",
                table: "ExpenseForms",
                column: "AuthorizeUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseForms_Users_AuthorizeUserId",
                table: "ExpenseForms",
                column: "AuthorizeUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseForms_Users_AuthorizeUserId",
                table: "ExpenseForms");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseForms_AuthorizeUserId",
                table: "ExpenseForms");

            migrationBuilder.DropColumn(
                name: "AuthorizeUserId",
                table: "ExpenseForms");
        }
    }
}
