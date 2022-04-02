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

        public static void GetLocations()
        {
            string csvFile = "Files/TacoBell-US-AL.csv";
            var locations = db.ReadAllRecords(csvFile);

            foreach (var l in locations)
            {
                var latitude = l.GeoPoint.Latitude;
                var longitude = l.GeoPoint.Longitude;
                var name = l.Name;
            }
        }

        public static void CreateLocation(ITrackable location)
        {
            var locations = db.ReadAllRecords(csvFile);
            locations.Add(location);
            db.WriteAllRecords(locations, csvFile);
        }

        public static void UpdateLatitude(double latitude)
        {
            var locations = db.ReadAllRecords(csvFile);
            locations[0].GeoPoint.Latitude = latitude;
            db.WriteAllRecords(locations, csvFile);
        }

        public static void UpdateLongitude(double longitude)
        {
            var locations = db.ReadAllRecords(csvFile);
            locations[1].GeoPoint.Longitude = longitude;
            db.WriteAllRecords(locations, csvFile);
        }

        public static void UpdateName(string name)
        {
            var locations = db.ReadAllRecords(csvFile);
            locations[2].Name = name;
            db.WriteAllRecords(locations, csvFile);
        }


        private static void RemoveLocation(int position)
        {
            var locations = db.ReadAllRecords(csvFile);
            locations.RemoveAt(position);
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
