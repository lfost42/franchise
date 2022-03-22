using System;
using GeoCoordinatePortable;

namespace ParserLibrary
{
    public class LocationModel : ITrackable
    {
        public string Name { get; set; }
        public GeoCoordinate GeoPoint { get; set; }

    }
}
