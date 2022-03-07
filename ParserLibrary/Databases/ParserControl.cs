using ParserLibrary.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserLibrary.Databases
{
    public class ParserControl
    {
        private static LocationLogger logger = new LocationLogger();
        private static ParserDataAccess parser = new ParserDataAccess();
        public List<ITrackable> ReadAllRecords(string csvFile)
        {
            string[] lines = File.ReadAllLines(csvFile);
            if (lines.Length == 0) logger.LogError("files has no input");
            if (lines.Length == 1) logger.LogInfo($"Lines: {lines[0]}");

            var locations = lines.Select(line => parser.Parse(line)).ToList();
            return locations;
        }

        public void GetFurthestLocations(List<ITrackable> locations)
        {            
            
            ITrackable location1 = null;
            ITrackable location2 = null;
            double distance = 0;

            logger.LogInfo("Log initialized, locating two locations furthest from one another.");

            for (int i = 0; i < locations.Count; i++)
            {
                var locA = locations[i];
                for (int j = 0; j < locations.Count; j++)
                {
                    var locB = locations[j];
                    if (locA.GeoPoint.GetDistanceTo(locB.GeoPoint) > distance)
                    {
                        distance = locA.GeoPoint.GetDistanceTo(locB.GeoPoint);

                        location1 = locA;
                        location2 = locB;
                    }
                }
            }

            double miles = distance * 0.00062;
            Console.WriteLine();
            logger.LogInfo($"{location1.Name} and {location2.Name} are {Math.Round(miles, 2)} miles apart.");
        }

    }
}
