using System;
using System.Collections.Generic;
using GeoCoordinatePortable;
using Parser.Data.Interfaces;

namespace Parser.Data.Models
{
    public class LocationModel : ITrackable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GeoCoordinate GeoPoint { get; set; }
    }
}
