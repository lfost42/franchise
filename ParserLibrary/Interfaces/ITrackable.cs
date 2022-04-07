using GeoCoordinatePortable;

namespace ParserLibrary
{
    public interface ITrackable
    {
        int Id { get; set; }
        string Name { get; set; }
        public GeoCoordinate GeoPoint { get; set; }
    }
}