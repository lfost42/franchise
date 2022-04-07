using System.Collections.Generic;

namespace ParserLibrary.Interfaces
{
    public interface IListModel
    {
        List<ITrackable> List { get; set; }
    }
}