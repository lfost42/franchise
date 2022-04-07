using System;
using System.Collections;
using System.Collections.Generic;

namespace ParserLibrary.Models
{
    public class DictModel : IDictModel
    {
        public IDictionary<int, LocationModel> mainDict { get; set; } = new Dictionary<int, LocationModel>();
        public List<LocationModel> mainLoc { get; set; } = new List<LocationModel>();
    }

}
