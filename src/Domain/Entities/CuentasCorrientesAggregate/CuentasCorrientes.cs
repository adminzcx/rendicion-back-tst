using Newtonsoft.Json;
using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Prome.Viaticos.Server.Domain.Entities.CuentaCorrienteAggregate
{
    [JsonObject(IsReference = true)]
    public class CuentasCorrientes : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public int Legajo { get; set; }
        public virtual Reason Reason { get; set; }
        public string Observaciones { get; set; }
        public decimal Monto { get; set; }
        public decimal? Km { get; set; }
    }
}
