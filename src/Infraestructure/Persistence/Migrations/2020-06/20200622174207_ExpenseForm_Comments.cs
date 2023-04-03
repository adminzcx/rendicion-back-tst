using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class ExpenseForm_Comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseFormComments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseFormId = table.Column<long>(nullable: true),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CommentUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseFormComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseFormComments_Users_CommentUserId",
                        column: x => x.CommentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpenseFormComments_ExpenseForms_ExpenseFormId",
                        column: x => x.ExpenseFormId,
                        principalTable: "ExpenseForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseFormComments_CommentUserId",
                table: "ExpenseFormComments",
                column: "CommentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseFormComments_ExpenseFormId",
                table: "ExpenseFormComments",
                column: "ExpenseFormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseFormComments");
        }
    }
}
