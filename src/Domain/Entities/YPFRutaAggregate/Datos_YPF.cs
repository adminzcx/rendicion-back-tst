using Prome.Viaticos.Server.Domain._Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prome.Viaticos.Server.Domain.Entities.YPFRutaAggregate
{
    public class Datos_YPF : BaseEntity
    {
        public Datos_YPF() : base() { }

        //public int YPFRutaId { get; set; }
        public DateTime? Fecha { get; set; }
        public string Contrato { get; set; }
        public string Subcuenta { get; set; }
        public string Centro_Costo { get; set; }
        public string Establecimiento { get; set; }
        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string Tarjeta { get; set; }
        public string Conductor { get; set; }
        public string Tipo_Identificacion_Conductor { get; set; }
        public string Nro_Identificacion_Conductor { get; set; }
        public string Tipo_Identificacion_Tarjeta { get; set; }
        public string Identificacion_Tarjeta { get; set; }
        public string Odometro { get; set; }
        public string Remito { get; set; }
        public string Producto { get; set; }
        public decimal? Litros_Unidades { get; set; }
        public decimal? Precio_PVP_Establecimiento { get; set; }
        public decimal? Imp_Total_PVP_Establecimiento { get; set; }
        public decimal? Precio_YER { get; set; }
        public decimal? Imp_Total_YER { get; set; }
        public string Divisa { get; set; }
        public string Factura { get; set; }
        public decimal? IVA { get; set; }
        public decimal? Imp_CO2 { get; set; }
        public decimal? Tasa_Vial { get; set; }
        public decimal? Imp_Comb_Liq { get; set; }
        public string Extracto { get; set; }
        public bool? Procesado { get; set; }
    }
}
