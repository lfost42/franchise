using System;
namespace ParserLibrary.Models
{
    public class SolutionModel
    {
        public string CsvFile { get; set; }
        public ITrackable Location1 { get; set; }
        public ITrackable Location2 { get; set; }
        public double Distance { get; set; }
        public string Message1 { get; set; }
        public string Message2 { get; set; }
        public string Message3 { get; set; }
        public string Message4 { get; set; }
    }
}
