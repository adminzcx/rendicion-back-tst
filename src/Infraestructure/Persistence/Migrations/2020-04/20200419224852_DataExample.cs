namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class DataExample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                insert into Categories
                values 
                ('JNR','Junior'),
                ('SSR','Semi Senior'),
                ('SR','Senior'),
                ('JF','Jefe'),
                ('GTE','Gerente'),
                ('VCE','Vice Presidente'),
                ('PTE','Presidente')

                insert into Zones
                values
                ('1', 'Norte'),
                ('2', 'Sur'),
                ('3', 'Oeste')

                insert into SubZones
                values
                ('1-1', 'Norte 1', 1),
                ('1-2', 'Norte 2', 1),
                ('2-1', 'Sur 1', 2),
                ('2-2', 'Sur 2', 2),
                ('3-1', 'Oeste 1', 3),
                ('3-2', 'Oeste 2', 3)

                insert into Branches
                values
                ('1-1-1', 'Sucrusal Norte 1', 1),
                ('1-2-1', 'Sucrusal Norte 2', 2),
                ('2-1-1', 'Sucrusal Sur 1', 3),
                ('2-2-1', 'Sucrusal Sur 2', 4),
                ('3-1-1', 'Sucrusal Oeste 1', 5),
                ('3-2-1', 'Sucrusal Oeste 2', 6)

                insert into Positions
                values 
                ('EC','Ejecutivo de cuenta'),
                ('ECS', 'Ejecutivo de cuenta supervisor'),
                ('JZ', 'Jefe de zona'),
                ('SGZ', 'Sub-gerente de zona'),
                ('GCM', 'Gerente de casa matriz'),
                ('ACM', 'Asistente de casa matriz'),
                ('JCM', 'Jefe de casa matriz')

                insert into Managements
                values 
                ('SIS', 'Sisetmas'),
                ('RED', 'Red'),
                ('FIN', 'Finanzas')

                insert into Sectors
                values 
                ('DES','Desarrollo',1),
                ('INF','Infraestructura',1),
                ('RED','Red',2),
                ('COM','Compras',3),
                ('PAG','Pagos',3)
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
