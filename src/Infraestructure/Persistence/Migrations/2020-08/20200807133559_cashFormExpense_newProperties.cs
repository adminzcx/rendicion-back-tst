using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class cashFormExpense_newProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DocumentAttached",
                table: "Expenses",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentAttached",
                table: "CashFormExpenses",
                maxLength: 400,
                nullable: true);


            migrationBuilder.Sql(@"
              GO
                SET IDENTITY_INSERT [dbo].[CostCenters] ON
                GO
                INSERT [dbo].[CostCenters] ([Id], [Name]) VALUES (8, N'Personas')
                GO
                 INSERT [dbo].[CostCenters] ([Id], [Name]) VALUES (9, N'Clientes')
                GO
                INSERT [dbo].[CostCenters] ([Id], [Name]) VALUES (10, N'Formación de colaboradores')
                GO
                INSERT [dbo].[CostCenters] ([Id], [Name]) VALUES (11, N'Gerencia general')
                GO
                INSERT [dbo].[CostCenters] ([Id], [Name]) VALUES (12, N'Reclutamiento y selección')
                GO
                SET IDENTITY_INSERT [dbo].[CostCenters] OFF
                GO
                SET IDENTITY_INSERT [dbo].[CashConcepts] ON 
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (31, N'Beneficio al personal ', 8, NULL)
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (32, N'Comité de clientes', 9, NULL)
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (33, N'Alojamiento de capacitación ', 10, NULL)
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (34, N'Promerienda con gerencia general ', 11, NULL)
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (35, N'Preocupacionales ', 12, NULL)
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (36, N'Alojamiento', 5, NULL)
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (37, N' Impuesto al sello, logística / correo,', 5, NULL)
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (38, N'Tarjeta de teléfono ', 5, NULL)
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (39, N'Viáticos por excepción', 5, NULL)
                GO
                SET IDENTITY_INSERT [dbo].[CashConcepts] OFF ");
        }



        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentAttached",
                table: "CashFormExpenses");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentAttached",
                table: "Expenses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 400,
                oldNullable: true);
        }
    }
}
