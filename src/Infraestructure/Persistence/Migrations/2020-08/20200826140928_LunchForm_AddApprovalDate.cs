using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class LunchForm_AddApprovalDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "LunchForm",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "LunchForm");
        }
    }
}
