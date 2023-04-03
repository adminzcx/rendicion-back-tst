using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class LunchAdvice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LunchAdvice",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LunchId = table.Column<long>(nullable: true),
                    AdviceDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchAdvice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LunchAdvice_Lunch_LunchId",
                        column: x => x.LunchId,
                        principalTable: "Lunch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LunchAdvice_LunchId",
                table: "LunchAdvice",
                column: "LunchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LunchAdvice");
        }
    }
}
