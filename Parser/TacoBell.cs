using System;
using GeoCoordinatePortable;

namespace Parser
{
    public class TacoBell : ITrackable
    {

        public TacoBell()
        {
        }

        public string Name { get; set; }
        public GeoCoordinate GeoPoint { get; set; }

    }
}
