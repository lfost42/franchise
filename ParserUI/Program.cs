using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using ParserLibrary;
using Microsoft.Extensions.Configuration;
using Grpc.Core;
using ServiceStack.Text;
using ParserLibrary.Data;
using ParserLibrary.Databases;

namespace ParserUI
{
    class Program
    {
        private static string csvFile;
        private static ParserControl control = new ParserControl();

        static void Main(string[] args)
        {
            csvFile = _config.GetValue<string>("TextFile");
            
            var locations = control.ReadAllRecords(csvFile);

            control.GetFurthestLocations(locations);
            Console.ReadLine();
        }

        private static IConfiguration _config;
        private static void InitializeConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _config = builder.Build();
        }

    }
}