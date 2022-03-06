using System;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace ParserLibrary.Data
{
    public class ParserDataAccess
    {        
        public ITrackable Parse(string line)
        {
            var cells = line.Split(',');
            if (cells.Length < 3) return null;

            var latitude = double.Parse(cells[0]);
            var longitude = double.Parse(cells[1]);
            var geoPoint = new GeoCoordinatePortable.GeoCoordinate(latitude, longitude);

            var location = new LocationModel();

            location.Name = cells[2];
            location.GeoPoint = geoPoint;

            return location;
        }
        
    }
}
