using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class CashForm_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                insert into CashFormStatus
                values 
                     ('Borrador'),
                     ('Presentado'),
                     ('Aprobado'),
                     ('Rechazado'),
                     ('Revisado')
                      ");

            migrationBuilder.Sql(@"
                insert into Organisms (name, isDefault) 
                    values ('Provincia Microempresas SA',1)
                     ");

            migrationBuilder.Sql(@"
               SET IDENTITY_INSERT [MoneyTypes] ON 
                            GO
                            INSERT [MoneyTypes] ([Id], [Name], [Value], [IsCoin], [IsDeleted]) VALUES (1, N'1000', CAST(1000.00 AS Decimal(18, 2)), 0, 0)
                            GO
                            INSERT [MoneyTypes] ([Id], [Name], [Value], [IsCoin], [IsDeleted]) VALUES (2, N'500', CAST(500.00 AS Decimal(18, 2)), 0, 0)
                            GO
                            INSERT [MoneyTypes] ([Id], [Name], [Value], [IsCoin], [IsDeleted]) VALUES (3, N'200', CAST(200.00 AS Decimal(18, 2)), 0, 0)
                            GO
                            INSERT [MoneyTypes] ([Id], [Name], [Value], [IsCoin], [IsDeleted]) VALUES (4, N'100', CAST(100.00 AS Decimal(18, 2)), 0, 0)
                            GO
                            INSERT [MoneyTypes] ([Id], [Name], [Value], [IsCoin], [IsDeleted]) VALUES (5, N'50', CAST(50.00 AS Decimal(18, 2)), 0, 0)
                            GO
                            INSERT [MoneyTypes] ([Id], [Name], [Value], [IsCoin], [IsDeleted]) VALUES (6, N'20', CAST(20.00 AS Decimal(18, 2)), 0, 0)
                            GO
                            INSERT [MoneyTypes] ([Id], [Name], [Value], [IsCoin], [IsDeleted]) VALUES (7, N'10', CAST(10.00 AS Decimal(18, 2)), 0, 0)
                            GO
                            INSERT [MoneyTypes] ([Id], [Name], [Value], [IsCoin], [IsDeleted]) VALUES (8, N'5', CAST(5.00 AS Decimal(18, 2)), 0, 0)
                            GO
                            INSERT [MoneyTypes] ([Id], [Name], [Value], [IsCoin], [IsDeleted]) VALUES (10, N'2', CAST(2.00 AS Decimal(18, 2)), 1, 0)
                            GO
                            INSERT [MoneyTypes] ([Id], [Name], [Value], [IsCoin], [IsDeleted]) VALUES (11, N'1', CAST(1.00 AS Decimal(18, 2)), 1, 0)
                            GO
                            INSERT [MoneyTypes] ([Id], [Name], [Value], [IsCoin], [IsDeleted]) VALUES (12, N'0.5', CAST(5.00 AS Decimal(18, 2)), 1, 0)
                            GO
                            INSERT [MoneyTypes] ([Id], [Name], [Value], [IsCoin], [IsDeleted]) VALUES (13, N'0.1', CAST(1.00 AS Decimal(18, 2)), 1, 0)
                            GO
                            SET IDENTITY_INSERT [MoneyTypes] OFF
                     ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
