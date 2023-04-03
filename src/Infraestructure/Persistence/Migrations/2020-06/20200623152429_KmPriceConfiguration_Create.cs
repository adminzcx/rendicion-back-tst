using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class KmPriceConfiguration_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KmPriceConfigurations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ZoneId = table.Column<long>(nullable: true),
                    SubZoneId = table.Column<long>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KmPriceConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KmPriceConfigurations_SubZones_SubZoneId",
                        column: x => x.SubZoneId,
                        principalTable: "SubZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KmPriceConfigurations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KmPriceConfigurations_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KmPriceConfigurations_SubZoneId",
                table: "KmPriceConfigurations",
                column: "SubZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_KmPriceConfigurations_UserId",
                table: "KmPriceConfigurations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_KmPriceConfigurations_ZoneId",
                table: "KmPriceConfigurations",
                column: "ZoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KmPriceConfigurations");
        }
    }
}
