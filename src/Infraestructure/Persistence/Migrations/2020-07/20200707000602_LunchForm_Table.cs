using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class LunchForm_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LunchFormId",
                table: "Lunch",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LunchFormStatus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchFormStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LunchForm",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<long>(nullable: false),
                    RestaurantId = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Cai = table.Column<DateTime>(nullable: false),
                    InvoiceType = table.Column<string>(maxLength: 1, nullable: false),
                    InvoiceNumber = table.Column<string>(maxLength: 100, nullable: false),
                    NumberOfTickets = table.Column<int>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    Iva = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    BussinesDays = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    StatusId = table.Column<long>(nullable: false),
                    PreviousStatusId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LunchForm_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LunchForm_LunchFormStatus_PreviousStatusId",
                        column: x => x.PreviousStatusId,
                        principalTable: "LunchFormStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LunchForm_Restaurant_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LunchForm_LunchFormStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "LunchFormStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LunchForm_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lunch_LunchFormId",
                table: "Lunch",
                column: "LunchFormId");

            migrationBuilder.CreateIndex(
                name: "IX_LunchForm_BranchId",
                table: "LunchForm",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LunchForm_PreviousStatusId",
                table: "LunchForm",
                column: "PreviousStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LunchForm_RestaurantId",
                table: "LunchForm",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_LunchForm_StatusId",
                table: "LunchForm",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LunchForm_UserId",
                table: "LunchForm",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lunch_LunchForm_LunchFormId",
                table: "Lunch",
                column: "LunchFormId",
                principalTable: "LunchForm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lunch_LunchForm_LunchFormId",
                table: "Lunch");

            migrationBuilder.DropTable(
                name: "LunchForm");

            migrationBuilder.DropTable(
                name: "LunchFormStatus");

            migrationBuilder.DropIndex(
                name: "IX_Lunch_LunchFormId",
                table: "Lunch");

            migrationBuilder.DropColumn(
                name: "LunchFormId",
                table: "Lunch");
        }
    }
}
