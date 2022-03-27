using System;
namespace ParserLibrary.Models
{
    public class SolutionModel
    {
        public string CsvFile { get; set; } = "";
        public ITrackable Location1 { get; set; } = null;
        public ITrackable Location2 { get; set; } = null;
        public double Distance { get; set; } = 0;
        public string FileName { get; set; } = "";
        public bool isPosted { get; set; } = false;
    }
}
