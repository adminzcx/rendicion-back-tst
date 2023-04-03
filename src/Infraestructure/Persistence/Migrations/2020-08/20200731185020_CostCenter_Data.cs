using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class CostCenter_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql(@"
            //   update CostCenters set name='Almuerzo' where id=1
            //   update CostCenters set name='Librería' where id=2
            //   update CostCenters set name='Gastos de infusión/limpieza' where id=3
            //   update CostCenters set name='Productos de computación' where id=4
            //   update CostCenters set name='Reunión en sucursales' where id=5
            //   update CostCenters set name='Otros' where id=5
            //   update CostCenters set name='Gastos de Cena' where id=6

            //   update CashConcepts set CostCenterId=1 where id in (2,3,4,5,6,7,8,9,10)
            //   update CashConcepts set CostCenterId=6 where id in (27,28)
            //   update CashConcepts set name='Gastos de librería', CostCenterId=2 where id in (15)
            //   update CashConcepts set  CostCenterId=3 where id in (16,17,12)
            //   update CashConcepts set CostCenterId=7 where id in (23)
            //   update CashConcepts set name='Gastos de infusiones' where id in (17)
            //   update CashConcepts set name='Productos de computación', Calipso='000205', CostCenterId=3 where id in (13)
            //   update CashConcepts set CostCenterId=5 where id in (20)
            //   update CashConcepts set name='Artículos de limpieza', CostCenterId=3 where id in (19) "); 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
