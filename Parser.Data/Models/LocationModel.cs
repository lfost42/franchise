using System;
using System.Collections.Generic;
using GeoCoordinatePortable;
using Franchise.Data.Interfaces;

namespace Franchise.Data.Models
{
    public class LocationModel : ITrackable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GeoCoordinate GeoPoint { get; set; }
    }
}
