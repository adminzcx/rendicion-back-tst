using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Lunch_AddLunchDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LunchDate",
                table: "Lunch",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LunchDate",
                table: "Lunch");
        }
    }
}
