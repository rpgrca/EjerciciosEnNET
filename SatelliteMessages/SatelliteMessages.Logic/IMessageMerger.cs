using System.Collections.Generic;

namespace SatelliteMessages.Logic
{
    public interface IMessageMerger
    {
        string Merge(List<string[]> brokenMessages);
    }
}