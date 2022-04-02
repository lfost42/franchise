using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using ParserLibrary.Databases;
using static System.Net.Mime.MediaTypeNames;

namespace ParserUI
{
    class Program
    {
        private static string csvFile = "TacoBell-US-AL.csv";
        private static ParserControl control = new ParserControl();

        static void Main(string[] args)
        {
            var locations = ParserControl.GetAllLocations(csvFile);
            control.GetFurthestLocations(locations);
            Console.ReadLine();
        }

    }
}