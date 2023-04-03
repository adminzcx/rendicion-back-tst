using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class ExpenseFormAudit_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "ExpenseFormAudits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseFormId = table.Column<long>(nullable: true),
                    AuditDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    StatusId = table.Column<long>(nullable: false),
                    AuditUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseFormAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseFormAudits_Users_AuditUserId",
                        column: x => x.AuditUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpenseFormAudits_ExpenseForms_ExpenseFormId",
                        column: x => x.ExpenseFormId,
                        principalTable: "ExpenseForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpenseFormAudits_ExpenseFormStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ExpenseFormStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseFormAudits_AuditUserId",
                table: "ExpenseFormAudits",
                column: "AuditUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseFormAudits_ExpenseFormId",
                table: "ExpenseFormAudits",
                column: "ExpenseFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseFormAudits_StatusId",
                table: "ExpenseFormAudits",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseFormAudits");


        }
    }
}
