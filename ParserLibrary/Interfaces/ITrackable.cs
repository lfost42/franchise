using GeoCoordinatePortable;

namespace ParserLibrary.Interfaces
{
    public interface ITrackable
    {
        int Id { get; set; }
        string Name { get; set; }
        public GeoCoordinate GeoPoint { get; set; }
    }
}