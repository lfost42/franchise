using GeoCoordinatePortable;

namespace Parser
{
    public interface ITrackable
    {
        string Name { get; set; }
        public GeoCoordinate GeoPoint { get; set; }
    }
}