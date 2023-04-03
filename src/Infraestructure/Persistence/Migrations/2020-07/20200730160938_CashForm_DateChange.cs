using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class CashForm_DateChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PresentacionDate",
                table: "CashForms");

            migrationBuilder.AddColumn<DateTime>(
                name: "PresentationDate",
                table: "CashForms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PresentationDate",
                table: "CashForms");

            migrationBuilder.AddColumn<DateTime>(
                name: "PresentacionDate",
                table: "CashForms",
                type: "datetime2",
                nullable: true);
        }
    }
}
