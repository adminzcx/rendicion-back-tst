using Ardalis.GuardClauses;
using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain.ValueObjects.ExpenseAggregate;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Prome.Viaticos.Server.Infraestructure.Maps
{
    public class MapService : IMapService
    {

        public Geolocation GetLatLongByAddress(Map request)
        {
            var result = new Geolocation();
            string url = request.Url;
            var parameters = url.Split("/");

            #region Positions
            var positions = parameters.First(x => x.Contains("@"));
            Guard.Against.Null(positions, nameof(positions));
            var locations = positions.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            var latitude = locations[0].Replace("@", "");
            result.Latitude = Convert.ToDouble(locations[0].Replace("@", ""), CultureInfo.InvariantCulture);
            result.Longitude = Convert.ToDouble(locations[1].ToString(), CultureInfo.InvariantCulture);
            #endregion

            #region Address

            Guard.Against.Null(positions, nameof(positions));

            result.Address = "";

            #endregion

            return result;

        }

        public Geolocation GetCurrentPosition(Map request)
        {

            Geolocation geolocationResult = new Geolocation
            {
                SourceLatitude = request.SourceLatitude,
                SourceLongitude = request.SourceLongitude
            };

            if (Math.Abs(request.Latitude) == 0 || Math.Abs(request.Longitude) == 0)
            {
                var tmpLocation = this.GetLatLongByAddress(request);
                if (tmpLocation == null) return null;
                request.Latitude = tmpLocation.Latitude;
                request.Longitude = tmpLocation.Longitude;
                geolocationResult.Latitude = tmpLocation.Latitude;
                geolocationResult.Longitude = tmpLocation.Longitude;
            }

            #region GetPoligono

            var googleRequest = new DirectionsRequest
            {
                Key = request.Token,
                Origin = new Location(request.SourceLatitude, request.SourceLongitude),
                Destination = new Location(request.Latitude, request.Longitude),
                TravelMode = 0,
                Alternatives = true
            };

            var result = GoogleMaps.Directions.Query(googleRequest);
            if (!result.Routes.Any()) return null;
            var overviewPath = result.Routes.First().OverviewPath;

            List<MapPath> points = new List<MapPath>();
            MapPath point = new MapPath { Points = overviewPath.Line.ToList() };
            points.Add(point);


            var distance = result.Routes.Sum(route => route.Legs.FirstOrDefault().Steps.Sum(s => s.Distance.Value));

            geolocationResult.Km = (decimal)((double)distance / (double)1000);
            #endregion

            #region GetImagen
            var imageRequest = new StaticMapsRequest
            {
                Key = request.Token,
                Paths = points
            };

            var imageResult = GoogleMaps.StaticMaps.Query(imageRequest);

            byte[] bytes = ((MemoryStream)imageResult.Stream).ToArray();

            geolocationResult.Map = bytes;
            #endregion

            return geolocationResult;
        }
    }
}
