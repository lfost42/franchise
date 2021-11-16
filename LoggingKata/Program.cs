using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized, locating two Taco Bells furthest from one another.");

            string[] lines = File.ReadAllLines(csvPath);
            if(lines.Length == 0) logger.LogError("files has no input");
            if(lines.Length == 1) logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(line => parser.Parse(line)).ToArray();

            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;
            double distance = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    if (locA.GeoPoint.GetDistanceTo(locB.GeoPoint) > distance)
                     {
                        distance = locA.GeoPoint.GetDistanceTo(locB.GeoPoint);
                        tacoBell1 = locA;
                        tacoBell2 = locB;
                     }
                }
            }

            double miles = distance * 0.00062;

            logger.LogInfo($"{tacoBell1.Name} and {tacoBell2.Name} are {Math.Round(miles,2)} miles apart.");
        }
    }
}