using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class CostCenterMissingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
              SET IDENTITY_INSERT [dbo].[CashConcepts] ON 
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (30, N'Gastos de Almuerzo 1 persona', NULL, N'000220')
                GO
                SET IDENTITY_INSERT [dbo].[CashConcepts] OFF ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
