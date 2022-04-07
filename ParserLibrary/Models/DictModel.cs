using System.Collections.Generic;

namespace ParserLibrary.Models
{
    public class DictModel
    {
        public IDictionary<int, LocationModel> GlobalDict { get; set; } = new Dictionary<int, LocationModel>();

    }
}
