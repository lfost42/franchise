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
        ParserMessage result = new ParserMessage();

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

        public ParserMessage GetFurthestLocations(List<ITrackable> locations)
        {
            result.Location1 = null;
            result.Location2 = null;
            result.Distance = 0;

            logger.LogInfo("Log initialized, locating two locations furthest from one another.");

            for (int i = 0; i < locations.Count; i++)
            {
                var locA = locations[i];
                for (int j = 0; j < locations.Count; j++)
                {
                    var locB = locations[j];
                    if (locA.GeoPoint.GetDistanceTo(locB.GeoPoint) > result.Distance)
                    {   
                        result.Location1 = locA;
                        result.Location2 = locB;
                        result.Distance = Math.Round(locA.GeoPoint.GetDistanceTo(locB.GeoPoint) * 0.00062, 2);
                        result.Message = $"{result.Location1.Name} and {result.Location2.Name} are {result.Distance} miles apart.";
                    }
                }
            }
            logger.LogInfo($"{result.Location1.Name} and {result.Location2.Name} are {result.Distance} miles apart.");
            //Console.WriteLine(result.Message);
            return result;
        }

    }
}
