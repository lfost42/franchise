using System;
using System.Collections.Generic;
using GeoCoordinatePortable;
using ParserLibrary.Interfaces;

namespace ParserLibrary.Models
{
    public class LocationModel : ITrackable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GeoCoordinate GeoPoint { get; set; }
    }
}
