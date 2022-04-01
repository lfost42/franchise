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
        [System.ComponentModel.Browsable(false)]
        public bool IsPostBack { get; }

        public SolutionModel solution = new SolutionModel();
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

        public ParserControl GetFurthestLocations(List<ITrackable> locations)
        {
            ParserControl result = new ParserControl();

            logger.LogInfo("Log initialized, locating two locations furthest from one another.");

            for (int i = 0; i < locations.Count; i++)
            {
                var locA = locations[i];
                for (int j = 0; j < locations.Count; j++)
                {
                    var locB = locations[j];
                    if (locA.GeoPoint.GetDistanceTo(locB.GeoPoint) > solution.Distance)
                    {
                        solution.Location1 = locA;
                        solution.Location2 = locB;
                        solution.Distance = Math.Round(locA.GeoPoint.GetDistanceTo(locB.GeoPoint) * 0.00062, 2);
                        solution.isPosted = true;
                    }
                }
            }
            logger.LogInfo($"{solution.Location1.Name} and {solution.Location2.Name} are {solution.Distance} miles apart.");
            return result;
        }

    }
}
