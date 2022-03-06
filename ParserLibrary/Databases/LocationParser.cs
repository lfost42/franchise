namespace ParserLibrary
{
    public class LocationParser
    {
        readonly ILog logger = new LocationLogger();
        
        public ITrackable Parse(string line)
        {

            var cells = line.Split(',');
            if (cells.Length < 3) return null;

            var numCells = cells.Length;
            var latitude = double.Parse(cells[0]);
            var longitude = double.Parse(cells[1]);
            var name = cells[2];

            var geoPoint = new GeoCoordinatePortable.GeoCoordinate(latitude, longitude);
            
            var location = new LocationModel();
            location.Name = name;
            location.GeoPoint = geoPoint;

            return location;
        }
    }
}