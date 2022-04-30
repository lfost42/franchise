using System.Collections.Generic;

namespace Parser.Data.Interfaces
{
    public interface IListModel
    {
        List<ITrackable> List { get; set; }
    }
}