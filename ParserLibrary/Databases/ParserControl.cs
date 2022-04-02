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
        public SolutionModel solution = new SolutionModel();
        private static LocationLogger logger = new LocationLogger();
        //Create Location
        //Update Location
        //Delete Location
        //Read Location

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
