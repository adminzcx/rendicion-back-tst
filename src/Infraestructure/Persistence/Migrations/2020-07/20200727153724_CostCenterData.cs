using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class CostCenterData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
               SET IDENTITY_INSERT [dbo].[CostCenters] ON 
                GO
                INSERT [dbo].[CostCenters] ([Id], [Name]) VALUES (1, N'Personas')
                GO
                INSERT [dbo].[CostCenters] ([Id], [Name]) VALUES (2, N'Clientes')
                GO
                INSERT [dbo].[CostCenters] ([Id], [Name]) VALUES (3, N'Formacion de Colaboradores')
                GO
                INSERT [dbo].[CostCenters] ([Id], [Name]) VALUES (4, N'Tecnologia & Procesos')
                GO
                INSERT [dbo].[CostCenters] ([Id], [Name]) VALUES (5, N'Gerencia General')
                GO
                INSERT [dbo].[CostCenters] ([Id], [Name]) VALUES (6, N'Reclutamiento y Selección')
                GO
                SET IDENTITY_INSERT [dbo].[CostCenters] OFF ");

            migrationBuilder.Sql(@"
              SET IDENTITY_INSERT [dbo].[CashConcepts] ON 
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (2, N'Gastos de Almuerzo 2 personas', NULL, N'000211')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (3, N'Gastos de Almuerzo 3 personas', NULL, N'000212')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (4, N'Gastos de Almuerzo 4 personas', NULL, N'000213')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (5, N'Gastos de Almuerzo 5 personas', NULL, N'000214')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (6, N'Gastos de Almuerzo 6 personas', NULL, N'000215')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (7, N'Gastos de Almuerzo 7 personas', NULL, N'000216')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (8, N'Gastos de Almuerzo 8 personas', NULL, N'000217')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (9, N'Gastos de Almuerzo 9 personas', NULL, N'000218')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (10, N'Gastos de Almuerzo 10 personas', NULL, N'000219')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (11, N'Alojamiento', NULL, N'000015')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (12, N'Artículos de Limpieza', NULL, N'000112')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (13, N'BENEFICIOS AL PERSONAL', 1, N'000065')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (14, N'Comité de Clientes', 2, N'000225')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (15, N'Gastos de Librería', NULL, N'000016')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (16, N'Gastos de Infusiones', NULL, N'000278')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (17, N'Impuesto al Sello', NULL, N'000025')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (18, N'Logística / Correo', NULL, N'000046')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (19, N'Alojamiento Capacitacion', 3, N'000098')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (20, N'Otros', NULL, N'000039')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (21, N'Productos de Computación', 4, N'000205')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (22, N'Promerienda Con Gerencia General', 5, N'000201')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (23, N'Reunión en Sucursales', NULL, N'000182')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (24, N'Tarjeta de Teléfono', NULL, N'000024')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (25, N'Viaticos por Excepción', NULL, N'000141')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (26, N'Preocupacionales', 6, N'000054')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (27, N'Gasto de Cena', NULL, N'000269')
                GO
                INSERT [dbo].[CashConcepts] ([Id], [Name], [CostCenterId], [Calipso]) VALUES (28, N'Gasto cena 2 personas', NULL, N'000270')
                GO
                SET IDENTITY_INSERT [dbo].[CashConcepts] OFF ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
