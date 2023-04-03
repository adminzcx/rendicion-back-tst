using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class ExpenseAdvice_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseAdvices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<long>(nullable: true),
                    AdviceDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseAdvices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseAdvices_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseAdvices_ExpenseId",
                table: "ExpenseAdvices",
                column: "ExpenseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseAdvices");
        }
    }
}
