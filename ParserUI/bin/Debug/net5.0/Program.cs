using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using ParserLibrary.Databases;

namespace ParserUI
{
    class Program
    {
        private static string csvFile;
        private static ParserControl control = new ParserControl();

        static void Main(string[] args)
        {
            InitializeConfiguration();

            csvFile = _config.GetValue<string>("TextFile");

            //var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location.Substring(0, Assembly.GetEntryAssembly().Location.IndexOf("bin\\")));
            //var filename = _config.GetValue<string>("TextFile");
            //csvFile = path + filename;

            //Console.WriteLine(csvFile);
            //Console.ReadLine();

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