using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Expense_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reasons",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalVisits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalVisits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Concepts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Form = table.Column<int>(nullable: false),
                    ReasonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concepts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concepts_Reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "Reasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonId = table.Column<long>(nullable: false),
                    ConceptId = table.Column<long>(nullable: false),
                    ExpenseDate = table.Column<DateTime>(nullable: false),
                    PresentationDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    DocumentAttached = table.Column<string>(maxLength: 100, nullable: true),
                    SegmentId = table.Column<long>(nullable: true),
                    SourceId = table.Column<long>(nullable: true),
                    GoogleURL = table.Column<string>(maxLength: 500, nullable: true),
                    TechnicalVisitId = table.Column<long>(nullable: true),
                    MobilityAmount = table.Column<decimal>(nullable: true),
                    VisitResult = table.Column<string>(maxLength: 10, nullable: true),
                    Term = table.Column<string>(maxLength: 30, nullable: true),
                    KM = table.Column<decimal>(nullable: true),
                    GoogleImage = table.Column<string>(nullable: true),
                    TotalAmount = table.Column<decimal>(nullable: true),
                    SourceLatitude = table.Column<string>(maxLength: 50, nullable: true),
                    SourceLongitude = table.Column<string>(maxLength: 50, nullable: true),
                    Latitude = table.Column<string>(maxLength: 50, nullable: true),
                    Longitude = table.Column<string>(maxLength: 50, nullable: true),
                    DNI = table.Column<string>(maxLength: 50, nullable: true),
                    RequestNumber = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Concepts_ConceptId",
                        column: x => x.ConceptId,
                        principalTable: "Concepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_Reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "Reasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Expenses_Segments_SegmentId",
                        column: x => x.SegmentId,
                        principalTable: "Segments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_Sources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Sources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_TechnicalVisits_TechnicalVisitId",
                        column: x => x.TechnicalVisitId,
                        principalTable: "TechnicalVisits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseUsers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseDate = table.Column<DateTime>(nullable: false),
                    ExpenseId = table.Column<long>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseUsers_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpenseUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concepts_ReasonId",
                table: "Concepts",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ConceptId",
                table: "Expenses",
                column: "ConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ReasonId",
                table: "Expenses",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_SegmentId",
                table: "Expenses",
                column: "SegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_SourceId",
                table: "Expenses",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TechnicalVisitId",
                table: "Expenses",
                column: "TechnicalVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseUsers_ExpenseId",
                table: "ExpenseUsers",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseUsers_UserId",
                table: "ExpenseUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalVisits_Code",
                table: "TechnicalVisits",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseUsers");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Concepts");

            migrationBuilder.DropTable(
                name: "Segments");

            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.DropTable(
                name: "TechnicalVisits");

            migrationBuilder.DropTable(
                name: "Reasons");
        }
    }
}
