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
        public string CsvFile { get; set; }
        public ITrackable Location1 { get; set; }
        public ITrackable Location2 { get; set; }
        public double Distance { get; set; }
        public string Message { get; set; }

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

        public ParserControl GetFurthestLocations(List<ITrackable> locations)
        {
            ParserControl result = new ParserControl();
            Location1 = null;
            Location2 = null;
            Distance = 0;

            logger.LogInfo("Log initialized, locating two locations furthest from one another.");

            for (int i = 0; i < locations.Count; i++)
            {
                var locA = locations[i];
                for (int j = 0; j < locations.Count; j++)
                {
                    var locB = locations[j];
                    if (locA.GeoPoint.GetDistanceTo(locB.GeoPoint) > Distance)
                    {   
                        Location1 = locA;
                        Location2 = locB;
                        Distance = Math.Round(locA.GeoPoint.GetDistanceTo(locB.GeoPoint) * 0.00062, 2);
                        Message = $"{Location1.Name} and {Location2.Name} are {Distance} miles apart.";
                    }
                }
            }
            logger.LogInfo($"{Location1.Name} and {Location2.Name} are {Distance} miles apart.");
            return result;
        }

    }
}
