using System.Collections.Generic;

namespace Parser.Data.Interfaces
{
    public interface IDatabaseData
    {
        ITrackable Parse(string csvFile);
        List<ITrackable> ReadAllRecords(string csvFile);
        void WriteAllRecords(List<ITrackable> locations, string csvFile);
    }
}