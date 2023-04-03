namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    using System;

    public partial class AddDisabledDateToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DisabledDate",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisabledDate",
                table: "Users");
        }
    }
}
