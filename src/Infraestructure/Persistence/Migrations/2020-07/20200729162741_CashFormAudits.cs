using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class CashFormAudits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashFormAudit",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashFormId = table.Column<long>(nullable: true),
                    AuditDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserPosition = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    AuditUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFormAudit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashFormAudit_Users_AuditUserId",
                        column: x => x.AuditUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashFormAudit_CashForms_CashFormId",
                        column: x => x.CashFormId,
                        principalTable: "CashForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashFormComment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashFormId = table.Column<long>(nullable: true),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CommentUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFormComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashFormComment_CashForms_CashFormId",
                        column: x => x.CashFormId,
                        principalTable: "CashForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashFormComment_Users_CommentUserId",
                        column: x => x.CommentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashFormAudit_AuditUserId",
                table: "CashFormAudit",
                column: "AuditUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CashFormAudit_CashFormId",
                table: "CashFormAudit",
                column: "CashFormId");

            migrationBuilder.CreateIndex(
                name: "IX_CashFormComment_CashFormId",
                table: "CashFormComment",
                column: "CashFormId");

            migrationBuilder.CreateIndex(
                name: "IX_CashFormComment_CommentUserId",
                table: "CashFormComment",
                column: "CommentUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashFormAudit");

            migrationBuilder.DropTable(
                name: "CashFormComment");
        }
    }
}
