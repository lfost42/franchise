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

            //NEW DICTIONARY
            //IDictionary<int, LocationModel> newDict = DictControl.CreateDict(csvFile);
            //DictControl.ToConsole(newDict);

            //CREATE
            //DictControl.AddLocation(newDict, (long)50, (long)50, "TempLoc");
            //DictControl.ToConsole(newDict);

            //READ
            //var viewloc = DictControl.ViewLocation(newDict, 200);
            //Console.WriteLine($"{viewloc.Id} {viewloc.GeoPoint} {viewloc.Name}");

            //UPDATE
            //DictControl.EditLocation(newDict, 3, (long)33.3333, (long)33.3333, "Changed");
            //DictControl.ToConsole(newDict);

            //DELETE
            //DictControl.DeleteLocation(newDict, 10);
            //DictControl.ToConsole(newDict);
            //Console.ReadLine();
        }

    }
}