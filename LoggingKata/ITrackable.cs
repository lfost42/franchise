using GeoCoordinatePortable;

namespace LoggingKata
{
    public interface ITrackable
    {
        string Name { get; set; }
        public GeoCoordinate GeoPoint { get; set; }
    }
}