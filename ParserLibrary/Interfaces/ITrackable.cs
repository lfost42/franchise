using GeoCoordinatePortable;

namespace ParserLibrary
{
    public interface ITrackable
    {
        string Name { get; set; }
        public GeoCoordinate GeoPoint { get; set; }
    }
}