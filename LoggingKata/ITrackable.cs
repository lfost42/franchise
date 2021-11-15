using GeoCoordinatePortable;

namespace LoggingKata
{
    public interface ITrackable
    {
        string Name { get; set; }
        Point Location { get; set; }
        public GeoCoordinate GeoPoint { get; set; }
    }
}