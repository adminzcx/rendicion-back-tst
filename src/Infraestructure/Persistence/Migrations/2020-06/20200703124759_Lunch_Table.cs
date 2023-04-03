using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Lunch_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lunch",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Collaborator = table.Column<string>(maxLength: 200, nullable: true),
                    EmployeeRecord = table.Column<string>(maxLength: 100, nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Device = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    CreatedUserId = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lunch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lunch_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lunch_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lunch_CreatedUserId",
                table: "Lunch",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lunch_UserId",
                table: "Lunch",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lunch");
        }
    }
}
