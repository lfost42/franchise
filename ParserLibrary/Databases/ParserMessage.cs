using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserLibrary.Databases
{
    public class ParserMessage
    {
        public string CsvFile { get; set; }
        public ITrackable Location1 { get; set; }
        public ITrackable Location2 { get; set; }
        public double Distance { get; set; }
        public string Message { get; set; }
            
    }
}
