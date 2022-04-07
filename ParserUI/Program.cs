using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using ParserLibrary;
using ParserLibrary.Databases;
using ParserLibrary.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ParserUI
{
    class Program
    {
        private static string csvFile = "TacoBell-US-AL.csv";
        private static ParserControl control = new ParserControl();

        static void Main(string[] args)
        {
            //var locations = ParserControl.GetAllLocations(csvFile);
            //control.GetFurthestLocations(locations);

            IDictionary<int, LocationModel> newDict = DictControl.CreateDict(csvFile);
            //foreach (KeyValuePair<int, LocationModel> kvp in newDict)
            //{
            //    Console.WriteLine($"{kvp.Key} {kvp.Value.GeoPoint.Latitude} {kvp.Value.GeoPoint.Longitude} {kvp.Value.Name}");
            //}

            DictModel mainDict = DictControl.DictToDictModel(newDict);
            foreach (MainDict.Keys key in mainDict)
            {

            }


            Console.ReadLine();
        }

    }
}