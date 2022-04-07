using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ParserLibrary.Data;
using ParserLibrary.Databases;
using ParserLibrary.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ParserUI
{
    class Program
    {
        //private static string csvFile = "TacoBell-US-AL.csv";
        private static ParserControl pars = new ParserControl();
        private static DictControl dict = new DictControl();
        private static DictModel mainDict = new DictModel();

        static void Main(string[] args)
        {
            //var locations = ParserControl.GetAllLocations(csvFile);
            //pars.GetFurthestLocations(locations);

            //var locations = dict.DictRecords(csvFile);
            //Console.WriteLine(dict.DictToString(locations));

            //var locations = dict.DictRecords(csvFile);
            //var result = dict.ViewLocation(locations, 200);
            //var location = $"{result.Item1} {result.Item2.GeoPoint.Latitude} {result.Item2.GeoPoint.Longitude} {result.Item2.Name}";
            //Console.WriteLine(location);

            //var locations = dict.DictRecords(csvFile);
            //var newLocations = locations.mainDict.Remove(3);
            //Console.WriteLine(dict.DictToString(locations));

            //Dictionary<string, string> localizedWelcomeLabels = new Dictionary<string, string>();
            //localizedWelcomeLabels.Add("en", "Welcome");
            //localizedWelcomeLabels.Add("fr", "Bienvenue");
            //localizedWelcomeLabels.Add("de", "Willkommen");
            //Console.WriteLine(JsonConvert.SerializeObject(localizedWelcomeLabels));

            //var locations = dict.DictRecords(csvFile);
            //ParserDataAccess.db.DictToJson(locations);

            var csvFile = "Files/TacoBell-US-AL.csv";
            var dict = DictControl.dictControl.DictRecords(csvFile);
            var locations = DictControl.dictControl.DictToModels(dict);
            foreach (var location in locations)
            {
                Console.WriteLine(location);
            }

            Console.ReadLine();
        }

    }
}