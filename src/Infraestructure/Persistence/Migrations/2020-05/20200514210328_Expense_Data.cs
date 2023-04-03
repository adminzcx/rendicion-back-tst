using Microsoft.EntityFrameworkCore.Migrations;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    public partial class Expense_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                insert into TechnicalVisits
                values 
                ('JNR','Visita 1'),
                ('SSR','Visita 2')");

            migrationBuilder.Sql(@"
                insert into Sources
                values 
                     ('Sucursal'),
                     ('Visita Anterior') 
                      ");

            migrationBuilder.Sql(@"
                insert into Segments
                values 
                     ('Comercio'),
                     ('Producción') 
                      ");


            migrationBuilder.Sql(@"
                insert into Reasons
                values 
                  ('Beneficio'),
                  ('Capacitación'),
                  ('Evaluación de terreno'),
                  ('Otras reuniones'),
                  ('Visita de cobranza'),
                  ('Reunión mensual'),
                  ('Traspaso de cartera'),
                  ('Visita a sucursal'),
                  ('Visita de campaña')");




            //Beneficios
            migrationBuilder.Sql(@"
                insert into Concepts
                values 
                     ('Alojamiento',1,1),
                     ('Guardería',1,1) ,
                     ('Refrigerio',1,1),
                     ('Estacionamiento',1,1),
                     ('Beneficio Fit',1,1),
                     ('Almuerzo',1,2),
                     ('Cena',1,2)");

            //Capacitación
            migrationBuilder.Sql(@"
                insert into Concepts
                values 
                     ('Peaje',1,2),
                     ('Estacionamiento',1,2),
                     ('Almuerzo',2,2),
                     ('Cena',2,2),
                     ('Auto',3,2),
                     ('Moto',3,2),
                     ('Taxi/Remis',4,2),
                     ('Trans. Público',4,2)");

            //Evaluación de terreno
            migrationBuilder.Sql(@"
                insert into Concepts
                values 
                     ('Peaje',1,3),
                     ('Estacionamiento',1,3),
                     ('Auto',5,3),
                     ('Moto',5,3),
                     ('Taxi/Remis',6,3),
                     ('Trans. Público',6,3)");

            //Otras reuniones
            migrationBuilder.Sql(@"
                insert into Concepts
                values 
                     ('Peaje',1,4),
                     ('Estacionamiento',1,4),
                     ('Auto',7,4),
                     ('Moto',7,4),
                     ('Taxi/Remis',8,4),
                     ('Trans. Público',8,4)");

            //Visita de cobranza
            migrationBuilder.Sql(@"
                insert into Concepts
                values 
                     ('Peaje',1,5),
                     ('Estacionamiento',1,5),
                     ('Auto',11,5),
                     ('Moto',11,5),
                     ('Taxi/Remis',12,5),
                     ('Trans. Público',12,5)");

            //Reunión mensual
            migrationBuilder.Sql(@"
                insert into Concepts
                values 
                     ('Peaje',1,6),
                     ('Estacionamiento',1,6),
                     ('Auto',7,6),
                     ('Moto',7,6),
                     ('Taxi/Remis',8,6),
                     ('Trans. Público',8,6)");

            //Traspaso de cartera
            migrationBuilder.Sql(@"
                insert into Concepts
                values 
                     ('Peaje',1,7),
                     ('Estacionamiento',1,7),
                     ('Auto',7,7),
                     ('Moto',7,7),
                     ('Taxi/Remis',8,7),
                     ('Trans. Público',8,7)");

            //Visita a sucursal
            migrationBuilder.Sql(@"
                insert into Concepts
                values 
                     ('Peaje',1,8),
                     ('Estacionamiento',1,8),
                     ('Auto',7,8),
                     ('Moto',7,8),
                     ('Taxi/Remis',8,8),
                     ('Trans. Público',8,8)");

            //Visita de campaña
            migrationBuilder.Sql(@"
                insert into Concepts
                values 
                     ('Peaje',1,9),
                     ('Estacionamiento',1,9),
                     ('Auto',9,9),
                     ('Moto',9,9),
                     ('Taxi/Remis',10,9),
                     ('Trans. Público',10,9)");


            migrationBuilder.Sql(@"
                update Concepts set form=2 where id in (6,7)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
