using System.Collections.Generic;

namespace ParserLibrary.Models
{
    public interface IListModel
    {
        List<ITrackable> List { get; set; }
    }
}