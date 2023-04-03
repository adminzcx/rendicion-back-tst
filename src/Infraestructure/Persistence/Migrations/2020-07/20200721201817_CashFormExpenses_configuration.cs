using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class CashFormExpenses_configuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashForms",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    BranchId = table.Column<long>(nullable: false),
                    OrganismId = table.Column<long>(nullable: false),
                    CashFormNumber = table.Column<string>(maxLength: 100, nullable: true),
                    SubTotalCoins = table.Column<decimal>(nullable: true),
                    SubTotalCash = table.Column<decimal>(nullable: true),
                    TotalCash = table.Column<decimal>(nullable: true),
                    CreditCardDate = table.Column<DateTime>(nullable: false),
                    TotalCreditCard = table.Column<decimal>(nullable: true),
                    TotalPendingCreditCard = table.Column<decimal>(nullable: true),
                    FundTotal = table.Column<decimal>(nullable: true),
                    Total = table.Column<decimal>(nullable: true),
                    TotalDifference = table.Column<decimal>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StatusId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashForms_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashForms_Organisms_OrganismId",
                        column: x => x.OrganismId,
                        principalTable: "Organisms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashForms_CashFormStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "CashFormStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashForms_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CashFormExpenses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    CashFormId = table.Column<long>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    Vendor = table.Column<string>(nullable: true),
                    Concept = table.Column<string>(maxLength: 50, nullable: true),
                    CostCenter = table.Column<string>(maxLength: 100, nullable: true),
                    Total = table.Column<decimal>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFormExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashFormExpenses_CashForms_CashFormId",
                        column: x => x.CashFormId,
                        principalTable: "CashForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashFormExpenses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashFormMoney",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashFormId = table.Column<long>(nullable: true),
                    MoneyTypeId = table.Column<long>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFormMoney", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashFormMoney_CashForms_CashFormId",
                        column: x => x.CashFormId,
                        principalTable: "CashForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashFormMoney_MoneyTypes_MoneyTypeId",
                        column: x => x.MoneyTypeId,
                        principalTable: "MoneyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CashFormMoney_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashFormExpenses_CashFormId",
                table: "CashFormExpenses",
                column: "CashFormId");

            migrationBuilder.CreateIndex(
                name: "IX_CashFormExpenses_UserId",
                table: "CashFormExpenses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CashFormMoney_CashFormId",
                table: "CashFormMoney",
                column: "CashFormId");

            migrationBuilder.CreateIndex(
                name: "IX_CashFormMoney_MoneyTypeId",
                table: "CashFormMoney",
                column: "MoneyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CashFormMoney_UserId",
                table: "CashFormMoney",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CashForms_BranchId",
                table: "CashForms",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CashForms_OrganismId",
                table: "CashForms",
                column: "OrganismId");

            migrationBuilder.CreateIndex(
                name: "IX_CashForms_StatusId",
                table: "CashForms",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CashForms_UserId",
                table: "CashForms",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashFormExpenses");

            migrationBuilder.DropTable(
                name: "CashFormMoney");

            migrationBuilder.DropTable(
                name: "CashForms");
        }
    }
}
