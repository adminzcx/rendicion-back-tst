using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class CashForm_AddPreviousStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PreviousStatusId",
                table: "CashForms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CashForms_PreviousStatusId",
                table: "CashForms",
                column: "PreviousStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_CashForms_CashFormStatus_PreviousStatusId",
                table: "CashForms",
                column: "PreviousStatusId",
                principalTable: "CashFormStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashForms_CashFormStatus_PreviousStatusId",
                table: "CashForms");

            migrationBuilder.DropIndex(
                name: "IX_CashForms_PreviousStatusId",
                table: "CashForms");

            migrationBuilder.DropColumn(
                name: "PreviousStatusId",
                table: "CashForms");
        }
    }
}
