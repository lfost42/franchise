using ParserLibrary.Data;
using ParserLibrary.Models;
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
        public SolutionModel solution = new SolutionModel();
        private static ParserDataAccess db = new ParserDataAccess();

        public static string csvFile = "Files/TacoBell-US-AL.csv";


        public static List<LocationModel> GetAllLocations(string csvFile)
        {
            List<LocationModel> locations = db
                .ReadAllRecords(csvFile)
                .Select(record => new LocationModel { Name = record.Name, GeoPoint = record.GeoPoint, Id = record.Id })
                .ToList();
            return locations;
        }

        public ParserControl GetFurthestLocations(List<LocationModel> locations)
        {
            ParserControl result = new ParserControl();

            logger.LogInfo("Log initialized, locating two locations furthest from one another.");
            solution.Distance = 0;
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
                        solution.Distance = locA.GeoPoint.GetDistanceTo(locB.GeoPoint);
                    }
                }
            }

            solution.isPosted = true;
            string fileName = csvFile.Substring(csvFile.IndexOf("/") + 1);
            solution.FileName = $"{fileName}";

            solution.Distance = Math.Round(solution.Distance * 0.00062, 2);
            logger.LogInfo($"{solution.Location1.Name} and {solution.Location2.Name} are {solution.Distance} miles apart.");
            return result;
        }

    }
}
