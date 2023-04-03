using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Expense_fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KmPriceConfigurations_SubZones_SubZoneId",
                table: "KmPriceConfigurations");

            migrationBuilder.DropForeignKey(
                name: "FK_KmPriceConfigurations_Users_UserId",
                table: "KmPriceConfigurations");

            migrationBuilder.DropForeignKey(
                name: "FK_KmPriceConfigurations_Zones_ZoneId",
                table: "KmPriceConfigurations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KmPriceConfigurations",
                table: "KmPriceConfigurations");

            migrationBuilder.RenameTable(
                name: "KmPriceConfigurations",
                newName: "KmPriceConfiguration");

            migrationBuilder.RenameIndex(
                name: "IX_KmPriceConfigurations_ZoneId",
                table: "KmPriceConfiguration",
                newName: "IX_KmPriceConfiguration_ZoneId");

            migrationBuilder.RenameIndex(
                name: "IX_KmPriceConfigurations_UserId",
                table: "KmPriceConfiguration",
                newName: "IX_KmPriceConfiguration_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_KmPriceConfigurations_SubZoneId",
                table: "KmPriceConfiguration",
                newName: "IX_KmPriceConfiguration_SubZoneId");

            //migrationBuilder.AddColumn<long>(
            //    name: "ExpenseFormId1",
            //    table: "Expenses",
            //    nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExpenseFormNumber",
                table: "ExpenseForms",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            //migrationBuilder.AddColumn<long>(
            //    name: "AuthorizeUserId",
            //    table: "ExpenseForms",
            //    nullable: true);

            //migrationBuilder.AddColumn<long>(
            //    name: "ExpenseFormId1",
            //    table: "ExpenseFormAudits",
            //    nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KmPriceConfiguration",
                table: "KmPriceConfiguration",
                column: "Id");

            //migrationBuilder.CreateTable(
            //    name: "ExpenseFormComments",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ExpenseFormId = table.Column<long>(nullable: true),
            //        CommentDate = table.Column<DateTime>(nullable: false),
            //        Description = table.Column<string>(maxLength: 200, nullable: true),
            //        CommentUserId = table.Column<long>(nullable: true),
            //        IsDeleted = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ExpenseFormComments", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ExpenseFormComments_Users_CommentUserId",
            //            column: x => x.CommentUserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_ExpenseFormComments_ExpenseForms_ExpenseFormId",
            //            column: x => x.ExpenseFormId,
            //            principalTable: "ExpenseForms",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Expenses_ExpenseFormId1",
            //    table: "Expenses",
            //    column: "ExpenseFormId1");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ExpenseForms_AuthorizeUserId",
            //    table: "ExpenseForms",
            //    column: "AuthorizeUserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ExpenseFormAudits_ExpenseFormId1",
            //    table: "ExpenseFormAudits",
            //    column: "ExpenseFormId1");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ExpenseFormComments_CommentUserId",
            //    table: "ExpenseFormComments",
            //    column: "CommentUserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ExpenseFormComments_ExpenseFormId",
            //    table: "ExpenseFormComments",
            //    column: "ExpenseFormId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ExpenseFormAudits_ExpenseForms_ExpenseFormId1",
            //    table: "ExpenseFormAudits",
            //    column: "ExpenseFormId1",
            //    principalTable: "ExpenseForms",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ExpenseForms_Users_AuthorizeUserId",
            //    table: "ExpenseForms",
            //    column: "AuthorizeUserId",
            //    principalTable: "Users",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Expenses_ExpenseForms_ExpenseFormId1",
            //    table: "Expenses",
            //    column: "ExpenseFormId1",
            //    principalTable: "ExpenseForms",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KmPriceConfiguration_SubZones_SubZoneId",
                table: "KmPriceConfiguration",
                column: "SubZoneId",
                principalTable: "SubZones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KmPriceConfiguration_Users_UserId",
                table: "KmPriceConfiguration",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KmPriceConfiguration_Zones_ZoneId",
                table: "KmPriceConfiguration",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ExpenseFormAudits_ExpenseForms_ExpenseFormId1",
            //    table: "ExpenseFormAudits");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseForms_Users_AuthorizeUserId",
                table: "ExpenseForms");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Expenses_ExpenseForms_ExpenseFormId1",
            //    table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_KmPriceConfiguration_SubZones_SubZoneId",
                table: "KmPriceConfiguration");

            migrationBuilder.DropForeignKey(
                name: "FK_KmPriceConfiguration_Users_UserId",
                table: "KmPriceConfiguration");

            migrationBuilder.DropForeignKey(
                name: "FK_KmPriceConfiguration_Zones_ZoneId",
                table: "KmPriceConfiguration");

            migrationBuilder.DropTable(
                name: "ExpenseFormComments");

            //migrationBuilder.DropIndex(
            //    name: "IX_Expenses_ExpenseFormId1",
            //    table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseForms_AuthorizeUserId",
                table: "ExpenseForms");

            //migrationBuilder.DropIndex(
            //    name: "IX_ExpenseFormAudits_ExpenseFormId1",
            //    table: "ExpenseFormAudits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KmPriceConfiguration",
                table: "KmPriceConfiguration");

            //migrationBuilder.DropColumn(
            //    name: "ExpenseFormId1",
            //    table: "Expenses");

            //migrationBuilder.DropColumn(
            //    name: "AuthorizeUserId",
            //    table: "ExpenseForms");

            //migrationBuilder.DropColumn(
            //    name: "ExpenseFormId1",
            //    table: "ExpenseFormAudits");

            migrationBuilder.RenameTable(
                name: "KmPriceConfiguration",
                newName: "KmPriceConfigurations");

            migrationBuilder.RenameIndex(
                name: "IX_KmPriceConfiguration_ZoneId",
                table: "KmPriceConfigurations",
                newName: "IX_KmPriceConfigurations_ZoneId");

            migrationBuilder.RenameIndex(
                name: "IX_KmPriceConfiguration_UserId",
                table: "KmPriceConfigurations",
                newName: "IX_KmPriceConfigurations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_KmPriceConfiguration_SubZoneId",
                table: "KmPriceConfigurations",
                newName: "IX_KmPriceConfigurations_SubZoneId");

            migrationBuilder.AlterColumn<string>(
                name: "ExpenseFormNumber",
                table: "ExpenseForms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KmPriceConfigurations",
                table: "KmPriceConfigurations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KmPriceConfigurations_SubZones_SubZoneId",
                table: "KmPriceConfigurations",
                column: "SubZoneId",
                principalTable: "SubZones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KmPriceConfigurations_Users_UserId",
                table: "KmPriceConfigurations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KmPriceConfigurations_Zones_ZoneId",
                table: "KmPriceConfigurations",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
