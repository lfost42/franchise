using System;
using System.Collections.Generic;
using GeoCoordinatePortable;

namespace ParserLibrary.Models
{
    public class LocationListModel : IListModel
    {
        public List<ITrackable> List { get; set; } = new List<ITrackable>();
    }
}
