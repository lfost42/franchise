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
        public static LocationListModel localList = new LocationListModel();

        public static string csvFile = "Files/TacoBell-US-AL.csv";


        public static List<ITrackable> GetAllLocations(string csvFile)
        {
            List<ITrackable> locations = db.ReadAllRecords(csvFile);
            return locations;
        }

        public static LocationListModel GetListLocations(string csvFile)
        {
            var locations = GetAllLocations(csvFile);
            foreach (ITrackable location in locations)
            {
                localList.List.Add(location);
            }
            return localList;
        }

        public static void CreateLocation(ITrackable location)
        {
            var list = GetListLocations(csvFile);
            list.List.Add(location);
        }

        public static void UpdateName(int Id, double longitude, double latitude, string name)
        {
            var list = GetListLocations(csvFile);
            list.List[Id].GeoPoint.Longitude = longitude;
            list.List[Id].GeoPoint.Latitude = latitude;
            list.List[Id].Name = name;
        }


        private static void RemoveLocation(int Id)
        {
            var list = GetListLocations(csvFile);
            list.List.RemoveAt(Id);
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
                        string fileName = csvFile.Substring(csvFile.IndexOf("/") + 1);
                        solution.FileName = $"{fileName}";
                    }
                }
            }
            logger.LogInfo($"{solution.Location1.Name} and {solution.Location2.Name} are {solution.Distance} miles apart.");
            return result;
        }

    }
}
