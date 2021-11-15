using System;
using GeoCoordinatePortable;

namespace LoggingKata
{
    public class TacoBell : ITrackable
    {

        public TacoBell()
        {
        }

        public string Name { get; set; }
        public Point Location { get; set; }
        public GeoCoordinate GeoPoint { get; set; }

    }
}
