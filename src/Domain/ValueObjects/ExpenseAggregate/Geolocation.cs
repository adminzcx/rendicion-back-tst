using System;

namespace Prome.Viaticos.Server.Domain.ValueObjects.ExpenseAggregate
{
    public class Geolocation
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Address { get; set; }

        public decimal Km { get; set; }

        public Byte[] Map { get; set; }

        public double SourceLatitude { get; set; }

        public double SourceLongitude { get; set; }
    }
}