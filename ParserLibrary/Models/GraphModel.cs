using System;
using System.Collections.Generic;

namespace ParserLibrary.Models
{
    public class GraphModel
    {
        public int Edge { get; set; } = 0;
        public int NumVertices { get; set; } = 0;
        public bool IsProcessed { get; set; } = false;
    }
}
