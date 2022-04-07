using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ParserLibrary.Databases;
using ParserLibrary.Models;

namespace ParserLibrary.Data
{
    public class ParserDataAccess : IDatabaseData
    {
        private static LocationLogger logger = new LocationLogger();
        public static ParserDataAccess db = new ParserDataAccess();
        //private static string csvFile = "TacoBell-US-AL.csv";

        public ITrackable Parse(string csvFile)
        {
            var cells = csvFile.Split(',');
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
            csvFile = "Files/TacoBell-US-AL.csv";
            string[] lines = File.ReadAllLines(csvFile);
            if (lines.Length == 0) logger.LogError("files has no input");
            if (lines.Length == 1) logger.LogInfo($"Lines: {lines[0]}");
            List<ITrackable> locations = lines.Select(line => db.Parse(line)).ToList();

            int idKey = 0;
            foreach (var location in locations)
            {
                idKey++;
                location.Id = idKey;
            }

            return locations;
        }

        public void WriteAllRecords(List<ITrackable> locations, string csvFile)
        {
            List<string> lines = new List<string>();

            foreach (var l in locations)
            {
                lines.Add($"{l.GeoPoint.Latitude},{l.GeoPoint.Longitude},{l.Name}");
            }
            string newFile = "$temp_{csvFile}";
            File.WriteAllLines(newFile, lines);
        }

        public string DictToJson(DictModel dict)
        {
            List<string> tolines = new List<string>();

            foreach (int key in dict.mainDict.Keys)
            {
                tolines.Add($"\"{dict.mainDict[key].ToString()}\"" +
                    $":[\"{dict.mainDict[key].Id.ToString()}\"" +
                    $",\"{dict.mainDict[key].GeoPoint.Latitude.ToString()}\"" +
                    $",\"{dict.mainDict[key].GeoPoint.Longitude.ToString()}\"" +
                    $",\"{dict.mainDict[key].Name.ToString()}\"],");
            }

            string final = "{" + tolines + "}";
            Console.WriteLine(final);
            return final;
        }

    }
}
