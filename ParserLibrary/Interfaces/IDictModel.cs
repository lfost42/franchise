using System.Collections.Generic;

namespace ParserLibrary.Models
{
    public interface IDictModel
    {
        IDictionary<int, LocationModel> mainDict { get; set; }
        List<LocationModel> mainLoc { get; set; }
    }
}