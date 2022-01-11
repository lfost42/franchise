namespace Parser
{
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
            var longitude = double.Parse(cells[1]);
            var name = cells[2];

            var geoPoint = new GeoCoordinatePortable.GeoCoordinate(latitude, longitude);
            
            var tacoBell = new TacoBell();
            tacoBell.Name = name;
            tacoBell.GeoPoint = geoPoint;

            return tacoBell;
        }
    }
}