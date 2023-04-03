namespace Prome.Viaticos.Server.Domain.ValueObjects.ExpenseAggregate
{
    public class Map
    {
        public string Url { get; set; }

        public string Token { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double SourceLatitude { get; set; }

        public double SourceLongitude { get; set; }
    }
}