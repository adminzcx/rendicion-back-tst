using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class LunchForm_AddComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LunchFormAudit",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LunchFormId = table.Column<long>(nullable: true),
                    AuditDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserPosition = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    AuditUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchFormAudit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LunchFormAudit_Users_AuditUserId",
                        column: x => x.AuditUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LunchFormAudit_LunchForm_LunchFormId",
                        column: x => x.LunchFormId,
                        principalTable: "LunchForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LunchFormComment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LunchFormId = table.Column<long>(nullable: true),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CommentUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchFormComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LunchFormComment_Users_CommentUserId",
                        column: x => x.CommentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LunchFormComment_LunchForm_LunchFormId",
                        column: x => x.LunchFormId,
                        principalTable: "LunchForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LunchFormAudit_AuditUserId",
                table: "LunchFormAudit",
                column: "AuditUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LunchFormAudit_LunchFormId",
                table: "LunchFormAudit",
                column: "LunchFormId");

            migrationBuilder.CreateIndex(
                name: "IX_LunchFormComment_CommentUserId",
                table: "LunchFormComment",
                column: "CommentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LunchFormComment_LunchFormId",
                table: "LunchFormComment",
                column: "LunchFormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LunchFormAudit");

            migrationBuilder.DropTable(
                name: "LunchFormComment");
        }
    }
}
