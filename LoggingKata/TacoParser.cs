namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            //logger.LogInfo("Begin parsing");

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                logger.LogWarning("less than three items, incomplete data");
                return null;
            }

            var numCells = cells.Length;
            var latitude = double.Parse(cells[0]);
            var longitutde = double.Parse(cells[1]);
            var name = cells[2];

            var point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitutde;

            var geoPoint = new GeoCoordinatePortable.GeoCoordinate();
            point.Latitude = geoPoint.Latitude;
            point.Longitude = geoPoint.Longitude;
            
            var tacoBell = new TacoBell();
            tacoBell.Name = name;
            tacoBell.Location = point;
            tacoBell.GeoPoint = geoPoint;

            return tacoBell;
        }
    }
}