using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Enums;

namespace Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate
{
    public class Concept : BaseNameEntity
    {
        public Concept(string name)
            : base(name)
        { }

        public int Form { get; set; }
        public virtual Reason Reason { get; private set; }

        public bool IsExpenseParquingLot => this.IsParquingLotType();

        public bool IsExpenseToll => this.IsTollType();

        public bool IsCarOrMotociclye => this.IsCarOrMotociclyeType();

        private bool IsParquingLotType()
        {
            switch (this.Id)
            {
                case (int)ConceptEnum.Estacionamiento_Beneficios:
                case (int)ConceptEnum.Estacionamiento_Capacitacion:
                case (int)ConceptEnum.Estacionamiento_Terreno:
                case (int)ConceptEnum.Estacionamiento_OtrasReuniones:
                case (int)ConceptEnum.Estacionamiento_Cobranza:
                case (int)ConceptEnum.Estacionamiento_ReunionMensual:
                case (int)ConceptEnum.Estacionamiento_TraspasoCartera:
                case (int)ConceptEnum.Estacionamiento_VisitaSucursal:
                case (int)ConceptEnum.Estacionamiento_VisitaCampania:
                    return true;
                default:
                    return false;
            }
        }

        private bool IsTollType()
        {
            switch (this.Id)
            {
                case (int)ConceptEnum.Peaje_Capacitacion:
                case (int)ConceptEnum.Peaje_Terreno:
                case (int)ConceptEnum.Peaje_OtrasReuniones:
                case (int)ConceptEnum.Peaje_Cobranza:
                case (int)ConceptEnum.Peaje_ReunionMensual:
                case (int)ConceptEnum.Peaje_TraspasoCartera:
                case (int)ConceptEnum.Peaje_VisitaSucursal:
                case (int)ConceptEnum.Peaje_VisitaCampania:
                    return true;
                default:
                    return false;
            }
        }

        private bool IsCarOrMotociclyeType()
        {
            switch (this.Id)
            {
                case (int)ConceptEnum.Auto_Capacitacion:
                case (int)ConceptEnum.Auto_Terreno:
                case (int)ConceptEnum.Auto_OtrasReuniones:
                case (int)ConceptEnum.Auto_Cobranza:
                case (int)ConceptEnum.Auto_ReunionMensual:
                case (int)ConceptEnum.Auto_TraspasoCartera:
                case (int)ConceptEnum.Auto_VisitaSucursal:
                case (int)ConceptEnum.Auto_VisitaCampania:
                case (int)ConceptEnum.Moto_Capacitacion:
                case (int)ConceptEnum.Moto_Terreno:
                case (int)ConceptEnum.Moto_OtrasReuniones:
                case (int)ConceptEnum.Moto_Cobranza:
                case (int)ConceptEnum.Moto_ReunionMensual:
                case (int)ConceptEnum.Moto_TraspasoCartera:
                case (int)ConceptEnum.Moto_VisitaSucursal:
                case (int)ConceptEnum.Moto_VisitaCampania:
                    return true;
                default:
                    return false;
            }
        }
    }
}