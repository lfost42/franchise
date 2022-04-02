using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ParserLibrary.Databases;
using ParserLibrary.Models;

namespace ParserLibrary.Data
{
    public class ParserDataAccess
    {
        private static LocationLogger logger = new LocationLogger();
        private static ParserDataAccess db = new ParserDataAccess();

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

        
        public List<ITrackable> ReadAllRecords(string csvFile)
        {
            string[] lines = File.ReadAllLines(csvFile);
            if (lines.Length == 0) logger.LogError("files has no input");
            if (lines.Length == 1) logger.LogInfo($"Lines: {lines[0]}");

            var locations = lines.Select(line => db.Parse(line)).ToList();
            return locations;
        }

        public void WriteAllRecords(List<ITrackable> locations, string csvFile)
        {
            List<string> lines = new List<string>();

            foreach (var l in locations)
            {
                lines.Add($"{l.GeoPoint.Latitude},{l.GeoPoint.Longitude},{l.Name}");
            }
            string newFile = "$new_{csvFile}";
            File.WriteAllLines(newFile, lines);
        }

    }
}
