using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Expense_AddCampaign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CampaignId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CampaignId",
                table: "Expenses",
                column: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Campaigns_CampaignId",
                table: "Expenses",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Campaigns_CampaignId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CampaignId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "Expenses");
        }
    }
}
