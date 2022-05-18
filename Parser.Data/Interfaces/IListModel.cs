using System.Collections.Generic;

namespace Franchise.Data.Interfaces
{
    public interface IListModel
    {
        List<ITrackable> List { get; set; }
    }
}