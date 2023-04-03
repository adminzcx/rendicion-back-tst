using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class CashFormChangesOnDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "CashForms");

            migrationBuilder.DropColumn(
                name: "TotalPendingCreditCard",
                table: "CashForms");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreditCardDate",
                table: "CashForms",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Period",
                table: "CashForms",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PresentacionDate",
                table: "CashForms",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPending",
                table: "CashForms",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TotalPendingDate",
                table: "CashForms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "CashForms");

            migrationBuilder.DropColumn(
                name: "PresentacionDate",
                table: "CashForms");

            migrationBuilder.DropColumn(
                name: "TotalPending",
                table: "CashForms");

            migrationBuilder.DropColumn(
                name: "TotalPendingDate",
                table: "CashForms");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreditCardDate",
                table: "CashForms",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "CashForms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPendingCreditCard",
                table: "CashForms",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
